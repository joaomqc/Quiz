namespace QuizManagement.Rpc
{
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
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            _container = ServiceResolver.Configure(configuration);
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
