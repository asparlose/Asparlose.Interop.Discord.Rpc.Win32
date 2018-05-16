using System;

namespace Asparlose.Interop.Discord.Rpc.Win32
{
    public class TokenEventArgs : EventArgs
    {
        public string Secret { get; }
        public TokenEventArgs(string secret) => Secret = secret;
    }
}
