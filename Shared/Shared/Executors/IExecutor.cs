using Shared.Operation;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Executors
{
    public interface IExecutor
    {
        Task<TResult> ExecuteAsync<TParam, TResult>(TParam parameters, CancellationToken ct = default(CancellationToken)) where TParam : IParameter where TResult : IResult;
    }
}
