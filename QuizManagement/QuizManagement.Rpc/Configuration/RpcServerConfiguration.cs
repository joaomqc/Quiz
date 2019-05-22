namespace QuizManagement.Rpc.Configuration
{
    using System;
    using Controllers;
    using Grpc.Core;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Shared.Contracts.QuizManagement.Quizzes;
    using Shared.Contracts.QuizManagement.Topics;

    public class RpcServerConfiguration
    {
        public static Server Configure(IServiceProvider container, IConfigurationRoot configuration)
        {
            var serverPort = Convert.ToInt32(configuration["RPC:ServerPort"]);

            var server = new Server
            {
                Services =
                {
                    QuizzesService.BindService(container.GetRequiredService<QuizzesController>()),
                    TopicsService.BindService(container.GetRequiredService<TopicsController>())
                },
                Ports = { new ServerPort("localhost", serverPort, ServerCredentials.Insecure)}
            };

            return server;
        }
    }
}
