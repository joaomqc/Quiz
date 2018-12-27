namespace Shared.Executors
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Castle.Windsor;
    using Operation;

    public class Executor : IExecutor
    {
        private readonly IWindsorContainer _container;

        public Executor(IWindsorContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public Task<TResult> ExecuteAsync<TParam, TResult>(TParam parameters)
            where TParam : IParameter
            where TResult : IResult
        {
            var handler = _container.Resolve<IHandler<TParam, TResult>>();
            
            return handler.ExecuteAsync(parameters);
        }
    }
}
