namespace QuizManagement.Rpc.Configuration
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using System.Reflection;
    using Application.Repositories;
    using Infrastructure;
    using Infrastructure.Repositories;
    using Microsoft.Extensions.Configuration;
    using Shared.Executors;
    using Shared.Operation;

    public class ServiceResolver
    {
        public static IWindsorContainer Configure(IConfigurationRoot configuration)
        {
            IWindsorContainer container = new WindsorContainer();

            container
                .Register(Classes
                    .FromAssembly(Assembly.GetCallingAssembly())
                    .Pick()
                    .If(t => t.Name.EndsWith("Controller"))
                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                    .LifestyleTransient())
                .Register(Component
                    .For<IExecutor>()
                    .ImplementedBy<Executor>()
                    .LifestyleTransient())
                .Register(Classes
                    .FromAssemblyInThisApplication(Assembly.GetCallingAssembly())
                    .BasedOn(typeof(IHandler<,>))
                    .WithServiceFromInterface()
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
                    .LifestyleTransient()
                    .DependsOn(Dependency.OnValue("connectionString", configuration["ConnectionStrings:DefaultConnection"])))
                .Register(Component
                    .For<IWindsorContainer>()
                    .Instance(container)
                    .LifestyleSingleton());

            return container;
        }
    }
}
