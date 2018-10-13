namespace QuizManagement.Application.Repositories
{
    using Domain;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IQuizzesRepository
    {
        Task<Quiz> GetByIdAsync(
            int quizId,
            CancellationToken ct = default(CancellationToken));

        Task<QuizzesPaged> GetByTopicPagedAsync(
            int topicId,
            int startIndex,
            int numberOfItems,
            CancellationToken ct = default(CancellationToken));

        Task<QuizzesPaged> GetAllByUserPagedAsync(
            int userId,
            int startIndex,
            int numberOfItems,
            CancellationToken ct = default(CancellationToken));

        Task<QuizzesPaged> GetPublicByUserPagedAsync(
            int userId,
            int startIndex,
            int numberOfItems,
            CancellationToken ct = default(CancellationToken));

        Task<QuizzesPaged> GetPublicPagedAsync(
            int startIndex,
            int numberOfItems,
            CancellationToken ct = default(CancellationToken));

        Task InsertAsync(
            Quiz quiz,
            CancellationToken ct = default(CancellationToken));

        Task RemoveByIdAsync(
            int quizId,
            CancellationToken ct = default(CancellationToken));

        Task RemoveAllByUserIdAsync(
            int userId,
            CancellationToken ct = default(CancellationToken));

        Task RemovePrivateByUserIdAsync(
            int userId,
            CancellationToken ct = default(CancellationToken));
    }
}
