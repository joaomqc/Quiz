namespace QuizManagement.Rpc
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Castle.Windsor;
    using Configuration;
    using Grpc.Core;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    public class Service : IHostedService
    {
        private IWindsorContainer _container;
        private Server _rpcServer;
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true);

            var configuration = builder.Build();

            _container = ServiceResolver.Configure(configuration);
            _rpcServer = RpcServerConfiguration.Configure(_container, configuration);

            _rpcServer.Start();

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _rpcServer.ShutdownAsync();
            _container.Dispose();
        }
    }
}
