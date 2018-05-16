namespace Asparlose.Interop.Discord.Rpc.Win32
{
    public class DiscordUser
    {
        public DiscordUser() { }
        internal DiscordUser(global::DiscordRpc.DiscordUser user)
        {
            UserId = user.userId;
            UserName = user.username;
            Discriminator = user.discriminator;
            Avatar = user.avatar;
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Discriminator { get; set; }
        public string Avatar { get; set; }
    }
}
