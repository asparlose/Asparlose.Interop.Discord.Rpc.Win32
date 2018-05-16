using System;

namespace Asparlose.Interop.Discord.Rpc.Win32
{
    public class DiscordRpc : IDisposable
    {
        readonly global::DiscordRpc.EventHandlers handlers = new global::DiscordRpc.EventHandlers();

        public DiscordRpc(string clientId)
        {
            global::DiscordRpc.dll.Initialize(clientId, ref handlers, true, "");

            handlers.readyCallback += ReadyCallback;
            handlers.disconnectedCallback += OnDisconnected;
            handlers.errorCallback += OnError;
            handlers.joinCallback += OnJoin;
            handlers.spectateCallback += OnSpectate;
            handlers.requestCallback += RequestCallback;
        }

        public void UpdatePresense(RichPresence presence)
        {
            global::DiscordRpc.UpdatePresence(presence.rp);
        }

        private void ReadyCallback(ref global::DiscordRpc.DiscordUser connectedUser)
            => OnReady(new DiscordUser(connectedUser));

        private void RequestCallback(ref global::DiscordRpc.DiscordUser request)
            => OnRequest(new DiscordUser(request));


        protected virtual void OnReady(DiscordUser user)
            => Ready?.Invoke(this, new UserEventArgs(user));

        protected virtual void OnDisconnected(int errorCode, string message)
            => Disconnected?.Invoke(this, new ErrorEventArgs(errorCode, message));

        protected virtual void OnError(int errorCode, string message)
            => Error?.Invoke(this, new ErrorEventArgs(errorCode, message));

        protected virtual void OnJoin(string secret)
            => Join?.Invoke(this, new TokenEventArgs(secret));

        protected virtual void OnSpectate(string secret)
            => Spectate?.Invoke(this, new TokenEventArgs(secret));

        protected virtual void OnRequest(DiscordUser user)
            => Request?.Invoke(this, new UserEventArgs(user));

        public event EventHandler<UserEventArgs> Ready;
        public event EventHandler<ErrorEventArgs> Disconnected;
        public event EventHandler<ErrorEventArgs> Error;
        public event EventHandler<TokenEventArgs> Join;
        public event EventHandler<TokenEventArgs> Spectate;
        public event EventHandler<UserEventArgs> Request;

        private bool disposedValue = false;

        public void ClearPresence() => global::DiscordRpc.dll.ClearPresence();
        public void RunCallbacks() => global::DiscordRpc.dll.RunCallbacks();
        public void Respond(string userId, DiscordRpcReply reply) => global::DiscordRpc.dll.Respond(userId, reply);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    global::DiscordRpc.dll.Shutdown();
                }

                disposedValue = true;
            }
        }

        ~DiscordRpc() => Dispose(false);
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
