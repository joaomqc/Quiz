namespace QuizManagement.Api.Configuration
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Microsoft.AspNetCore.Mvc;
    using System.Reflection;
    using Application.Repositories;
    using Castle.Windsor.MsDependencyInjection;
    using Infrastructure;
    using Infrastructure.Repositories;
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
                    .For<ITopicsRepository>()
                    .ImplementedBy<TopicsRepository>()
                    .LifestyleTransient())
                .Register(Component
                    .For<IQuizzesRepository>()
                    .ImplementedBy<QuizzesRepository>()
                    .LifestyleTransient())
                .Register(Component
                    .For<QuizContext>()
                    .ImplementedBy<QuizContext>()
                    .LifestyleTransient())
                .Register(Component
                    .For<IConfiguration>()
                    .Instance(configuration)
                    .LifestyleSingleton());

            _serviceProvider =
                WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}
