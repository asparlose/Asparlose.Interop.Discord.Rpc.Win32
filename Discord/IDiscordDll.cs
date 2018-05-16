interface IDiscordDll
{
    void Initialize(string applicationId, ref DiscordRpc.EventHandlers handlers, bool autoRegister, string optionalSteamId);
    void Shutdown();
    void RunCallbacks();
    void UpdatePresenceNative(ref DiscordRpc.RichPresenceStruct presence);
    void ClearPresence();
    void Respond(string userId, Asparlose.Interop.Discord.Rpc.Win32.DiscordRpcReply reply);
    void UpdateHandlers(ref DiscordRpc.EventHandlers handlers);
}