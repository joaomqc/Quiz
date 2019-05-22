namespace UserManagement.RPC.Configuration
{
    using Application.Repositories;
    using Application.Services;
    using Infrastructure;
    using Infrastructure.Repositories;
    using Infrastructure.Services;
    using Lamar;
    using Microsoft.Extensions.Configuration;
    using Shared.Executors;
    using Shared.Operation;

    public class ServicesConfiguration
    {
        public static Container Configure(IConfigurationRoot configuration)
        {
            var container = new Container(c =>
            {
                c.For<IExecutor>()
                    .Use<Executor>()
                    .Singleton();

                c.Scan(scan =>
                {
                    scan.Assembly("UserManagement.Application");
                    scan.ConnectImplementationsToTypesClosing(typeof(IHandler<,>));
                });

                c.For<IUsersRepository>()
                    .Use<UsersRepository>();

                c.For<UserContext>()
                    .Use<UserContext>()
                    .Ctor<string>("connectionString")
                    .Is(configuration["ConnectionStrings:DefaultConnection"]);

                c.For<IPasswordHasher>()
                    .Use<PasswordHasher>();
                
                c.For<ITokenService>()
                    .Use<TokenService>()
                    .Ctor<int>("expiryTime")
                    .Is(int.Parse(configuration["JWT:ExpiryTime"]))
                    .Ctor<string>("audience")
                    .Is(configuration["JWT:Audience"])
                    .Ctor<string>("issuer")
                    .Is(configuration["JWT:Issuer"])
                    .Ctor<string>("signingKey")
                    .Is(configuration["JWT:SigningKey"]);
            });

            return container;
        }
    }
}
