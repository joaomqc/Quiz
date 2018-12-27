using Shared.Operation;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Executors
{
    public interface IExecutor
    {
        Task<TResult> ExecuteAsync<TParam, TResult>(TParam parameters) where TParam : IParameter where TResult : IResult;
    }
}
