using System;

namespace Asparlose.Interop.Discord.Rpc.Win32
{
    public class ErrorEventArgs : EventArgs
    {
        public int ErrorCode { get; }
        public string Message { get; }

        public ErrorEventArgs(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }
    }
}
