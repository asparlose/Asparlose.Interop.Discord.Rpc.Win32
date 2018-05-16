using System.Runtime.InteropServices;

class DiscordDll64 : IDiscordDll
{
    [DllImport("discord-rpc_x64", EntryPoint = "Discord_Initialize", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Initialize(string applicationId, ref DiscordRpc.EventHandlers handlers, bool autoRegister, string optionalSteamId);

    [DllImport("discord-rpc_x64", EntryPoint = "Discord_Shutdown", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Shutdown();

    [DllImport("discord-rpc_x64", EntryPoint = "Discord_RunCallbacks", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RunCallbacks();

    [DllImport("discord-rpc_x64", EntryPoint = "Discord_UpdatePresence", CallingConvention = CallingConvention.Cdecl)]
    private static extern void UpdatePresenceNative(ref DiscordRpc.RichPresenceStruct presence);

    [DllImport("discord-rpc_x64", EntryPoint = "Discord_ClearPresence", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ClearPresence();

    [DllImport("discord-rpc_x64", EntryPoint = "Discord_Respond", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Respond(string userId, Asparlose.Interop.Discord.Rpc.Win32.DiscordRpcReply reply);

    [DllImport("discord-rpc_x64", EntryPoint = "Discord_UpdateHandlers", CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateHandlers(ref DiscordRpc.EventHandlers handlers);

    void IDiscordDll.ClearPresence() => ClearPresence();
    void IDiscordDll.Initialize(string applicationId, ref DiscordRpc.EventHandlers handlers, bool autoRegister, string optionalSteamId) => Initialize(applicationId, ref handlers, autoRegister, optionalSteamId);
    void IDiscordDll.Respond(string userId, Asparlose.Interop.Discord.Rpc.Win32.DiscordRpcReply reply) => Respond(userId, reply);
    void IDiscordDll.RunCallbacks() => RunCallbacks();
    void IDiscordDll.Shutdown() => Shutdown();
    void IDiscordDll.UpdateHandlers(ref DiscordRpc.EventHandlers handlers) => UpdateHandlers(ref handlers);
    void IDiscordDll.UpdatePresenceNative(ref DiscordRpc.RichPresenceStruct presence) => UpdatePresenceNative(ref presence);
}

