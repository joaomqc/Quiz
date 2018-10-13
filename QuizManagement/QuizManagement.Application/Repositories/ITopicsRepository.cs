namespace QuizManagement.Application.Repositories
{
    using QuizManagement.Domain;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITopicsRepository
    {
        Task<IEnumerable<Topic>> GetAllAsync(CancellationToken ct = default(CancellationToken));

        Task<Topic> GetByIdAsync(
            int topicId,
            CancellationToken ct = default(CancellationToken));
    }
}
