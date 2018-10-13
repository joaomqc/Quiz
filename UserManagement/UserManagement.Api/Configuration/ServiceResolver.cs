namespace UserManagement.Api.Configuration
{
    using System;
    using System.Reflection;
    using Application;
    using Application.Repositories;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.MsDependencyInjection;
    using Infrastructure;
    using Infrastructure.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Shared.Executors;
    using Shared.Operation;

    public class ServiceResolver
    {
        private static IServiceProvider _serviceProvider;

        public ServiceResolver(
            IServiceCollection services,
            IConfiguration configuration)
        {
            IWindsorContainer container = new WindsorContainer();

            container
                .Register(Classes
                    .FromAssembly(Assembly.GetCallingAssembly())
                    .BasedOn(typeof(ControllerBase))
                    .LifestyleTransient())
                .Register(Component
                    .For<IExecutor>()
                    .ImplementedBy<Executor>()
                    .LifestyleTransient())
                .Register(Classes
                    .FromAssembly(Assembly.GetCallingAssembly())
                    .BasedOn(typeof(IHandler<,>))
                    .LifestyleTransient())
                .Register(Component
                    .For<IUserRepository>()
                    .ImplementedBy<UserRepository>()
                    .LifestyleTransient())
                .Register(Component
                    .For<UserContext>()
                    .ImplementedBy<UserContext>()
                    .LifestyleTransient())
                .Register(Component
                    .For<IConfiguration>()
                    .Instance(configuration)
                    .LifestyleSingleton())
                .Register(Component
                    .For<IPasswordHasher>()
                    .ImplementedBy<PasswordHasher>()
                    .LifestyleTransient());

            _serviceProvider =
                WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}
