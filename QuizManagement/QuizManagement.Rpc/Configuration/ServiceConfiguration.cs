namespace QuizManagement.Rpc.Configuration
{
    using Application.Repositories;
    using Infrastructure;
    using Infrastructure.Repositories;
    using Lamar;
    using Microsoft.Extensions.Configuration;
    using Shared.Executors;
    using Shared.Operation;

    public class ServiceConfiguration
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
                    scan.Assembly("QuizManagement.Application");
                    scan.ConnectImplementationsToTypesClosing(typeof(IHandler<,>));
                });

                c.For<ITopicsRepository>()
                    .Use<TopicsRepository>();

                c.For<IQuizzesRepository>()
                    .Use<QuizzesRepository>();

                c.For<QuizContext>()
                    .Use<QuizContext>();
            });

            return container;
        }
    }
}
