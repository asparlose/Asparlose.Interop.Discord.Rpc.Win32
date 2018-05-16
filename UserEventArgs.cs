using System;

namespace Asparlose.Interop.Discord.Rpc.Win32
{
    public class UserEventArgs : EventArgs
    {
        public DiscordUser User { get; }
        public UserEventArgs(DiscordUser user) => User = user;
    }
}
