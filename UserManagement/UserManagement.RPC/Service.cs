namespace UserManagement.RPC
{
    using System.IO;
    using Castle.Windsor;
    using Configuration;
    using Grpc.Core;
    using Microsoft.Extensions.Configuration;
    using Topshelf;

    public class Service : ServiceControl
    {
        private IWindsorContainer _container;
        private Server _rpcServer;

        public bool Start(HostControl hostControl)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            _container = ServiceResolver.Configure();
            _rpcServer = RpcServerConfiguration.Configure(_container, configuration);

            _rpcServer.Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _rpcServer.ShutdownAsync().Wait();
            _container.Dispose();

            return true;
        }
    }
}
