namespace UserManagement.RPC.Configuration
{
    using System;
    using Castle.Windsor;
    using Controllers;
    using Grpc.Core;
    using Microsoft.Extensions.Configuration;
    using Shared.Contracts.UserManagement.Users;

    public class RpcServerConfiguration
    {
        public static Server Configure(IWindsorContainer container, IConfigurationRoot configuration)
        {
            var serverPort = Convert.ToInt32(configuration["RPC:ServerPort"]);

            var server = new Server
            {
                Services =
                {
                    UsersService.BindService(container.Resolve<UsersController>())
                },
                Ports = { new ServerPort("localhost", serverPort, ServerCredentials.Insecure) }
            };

            return server;
        }
    }
}
