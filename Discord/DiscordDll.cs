using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
delegate void InitializeFunc(string applicationId, ref DiscordRpc.EventHandlers handlers, bool autoRegister, string optionalSteamId);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
delegate void UpdatePresenceFunc(ref DiscordRpc.RichPresenceStruct presence);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
delegate void RespondFunc(string userId, Asparlose.Interop.Discord.Rpc.Win32.DiscordRpcReply reply);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
delegate void UpdateHandlersFunc(ref DiscordRpc.EventHandlers handlers);

class DiscordDll : Asparlose.Interop.Win32.DynamicLinkFromBinary
{
    public InitializeFunc Initialize { get; }
    public Action Shutdown { get; }
    public Action RunCallbacks { get; }
    public UpdatePresenceFunc UpdatePresence { get; }
    public Action ClearPresence { get; }
    public RespondFunc Respond { get; }
    public UpdateHandlersFunc UpdateHandlers { get; }

    public DiscordDll(byte[] binary) : base(binary)
    {
        Initialize = GetProc<InitializeFunc>("Discord_Initialize");
        Shutdown = GetProc<Action>("Discord_Shutdown");
        RunCallbacks = GetProc<Action>("Discord_RunCallbacks");
        UpdatePresence = GetProc<UpdatePresenceFunc>("Discord_UpdatePresence");
        ClearPresence = GetProc<Action>("Discord_ClearPresence");
        Respond = GetProc<RespondFunc>("Discord_Respond");
        UpdateHandlers = GetProc<UpdateHandlersFunc>("Discord_UpdateHandlers");

        Debug.WriteLine($"discord-rpc.dll is exported: \"{FilePath}\".");
    }

    public static DiscordDll Create()
    {
        if (Environment.Is64BitProcess)
            return new DiscordDll(Asparlose.Interop.Discord.Rpc.Win32.SharedLibraries.discord_rpc_64);
        else
            return new DiscordDll(Asparlose.Interop.Discord.Rpc.Win32.SharedLibraries.discord_rpc_32);
    }
}
