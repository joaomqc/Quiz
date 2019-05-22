namespace UserManagement.RPC.Configuration
{
    using System;
    using Controllers;
    using Grpc.Core;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Shared.Contracts.UserManagement.Users;

    public class RpcServerConfiguration
    {
        public static Server Configure(IServiceProvider container, IConfigurationRoot configuration)
        {
            var serverPort = Convert.ToInt32(configuration["RPC:ServerPort"]);

            var server = new Server
            {
                Services =
                {
                    UsersService.BindService(container.GetRequiredService<UsersController>())
                },
                Ports = { new ServerPort("localhost", serverPort, ServerCredentials.Insecure) }
            };

            return server;
        }
    }
}
