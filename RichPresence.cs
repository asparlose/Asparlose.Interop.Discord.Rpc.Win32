using System;
using System.Text;

namespace Asparlose.Interop.Discord.Rpc.Win32
{
    public class RichPresence
    {
        internal readonly global::DiscordRpc.RichPresence rp = new global::DiscordRpc.RichPresence();

        static string CheckLength(string value)
        {
            if (Encoding.UTF8.GetByteCount(value) > 128)
                throw new ArgumentException("Text too long (max 128 bytes in utf-8)", nameof(value));

            return value;
        }

        public string State
        {
            get => rp.state;
            set => rp.state = CheckLength(value);
        }

        public string Details
        {
            get => rp.details;
            set => rp.details = CheckLength(value);
        }

        public string LargeImageKey
        {
            get => rp.largeImageKey;
            set => rp.largeImageKey = CheckLength(value);
        }

        public string LargeImageText
        {
            get => rp.largeImageText;
            set => rp.largeImageText = CheckLength(value);
        }

        public string SmallImageKey
        {
            get => rp.smallImageKey;
            set => rp.smallImageKey = CheckLength(value);
        }

        public string SmallImageText
        {
            get => rp.smallImageText;
            set => rp.smallImageText = CheckLength(value);
        }

        public string PartyId
        {
            get => rp.partyId;
            set => rp.partyId = CheckLength(value);
        }

        public string MatchSecret
        {
            get => rp.matchSecret;
            set => rp.matchSecret = CheckLength(value);
        }

        public string JoinSecret
        {
            get => rp.joinSecret;
            set => rp.joinSecret = CheckLength(value);
        }

        public string SpectateSecret
        {
            get => rp.spectateSecret;
            set => rp.spectateSecret = CheckLength(value);
        }

        public DateTime StartTime
        {
            get => Epoch.GetLocalTime(rp.startTimestamp);
            set => rp.startTimestamp = value.UnixEpoch();
        }

        public DateTime EndTime
        {
            get => Epoch.GetLocalTime(rp.endTimestamp);
            set => rp.endTimestamp = value.UnixEpoch();
        }

        public int PartySize
        {
            get => rp.partySize;
            set => rp.partySize = value;
        }

        public int PartyMax
        {
            get => rp.partyMax;
            set => rp.partyMax = value;
        }

        public bool Instance
        {
            get => rp.instance;
            set => rp.instance = value;
        }
    }
}
