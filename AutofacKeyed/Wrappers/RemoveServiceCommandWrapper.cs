using System;

namespace AutofacKeyed.Wrappers
{
    public class RemoveServiceCommandWrapper<TV, TW> : BaseCommandWrapper<TV, TW>
    {
        private readonly IRemoteClient _remoteClient;

        public RemoveServiceCommandWrapper(IRemoteClient remoteClient)
        {
            _remoteClient = remoteClient;
        }

        protected override TW DoExecute(TV request)
        {
            _remoteClient.Execute("Connecting to some remote service");
            return default(TW);
        }
    }

    public interface IRemoteClient
    {
        void Execute(string message);
    }

    public class RemoteClient : IRemoteClient
    {
        public void Execute(string message)
        {
            Console.WriteLine(message);
        }
    }
}
