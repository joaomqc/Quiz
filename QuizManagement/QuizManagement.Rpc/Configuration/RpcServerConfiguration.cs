namespace QuizManagement.Rpc.Configuration
{
    using System;
    using Castle.Windsor;
    using Controllers;
    using Grpc.Core;
    using Microsoft.Extensions.Configuration;
    using Shared.Contracts.QuizManagement.Quizzes;
    using Shared.Contracts.QuizManagement.Topics;

    public class RpcServerConfiguration
    {
        public static Server Configure(IWindsorContainer container, IConfigurationRoot configuration)
        {
            var serverPort = Convert.ToInt32(configuration["RPC:ServerPort"]);

            var server = new Server
            {
                Services =
                {
                    QuizzesService.BindService(container.Resolve<QuizzesController>()),
                    TopicsService.BindService(container.Resolve<TopicsController>())
                },
                Ports = { new ServerPort("localhost", serverPort, ServerCredentials.Insecure)}
            };

            return server;
        }
    }
}
