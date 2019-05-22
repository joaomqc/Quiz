namespace Shared.Executors
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Operation;

    public class Executor : IExecutor
    {
        private readonly IServiceProvider _container;

        public Executor(IServiceProvider container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public Task<TResult> ExecuteAsync<TParam, TResult>(TParam parameters)
            where TParam : IParameter
            where TResult : IResult
        {
            var handler = _container.GetRequiredService<IHandler<TParam, TResult>>();

            return handler.ExecuteAsync(parameters);
        }
    }
}
