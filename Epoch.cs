using System;

namespace Asparlose.Interop.Discord.Rpc.Win32
{
    static class Epoch
    {
        private static DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static long UnixEpoch(this DateTime dateTime)
        {
            return (long)((dateTime.ToUniversalTime() - UNIX_EPOCH).TotalSeconds);
        }

        public static DateTime GetUTC(long unixEpoch)
        {
            return UNIX_EPOCH + TimeSpan.FromSeconds(unixEpoch);
        }

        public static DateTime GetLocalTime(long unixEpoch)
        {
            return GetUTC(unixEpoch).ToLocalTime();
        }
    }
}
