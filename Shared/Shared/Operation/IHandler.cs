namespace Shared.Operation
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IHandler<P, R> where P : IParameter where R : IResult
    {
        Task<R> ExecuteAsync(P parameters);
    }
}
