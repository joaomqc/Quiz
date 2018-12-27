namespace QuizManagement.Application.Repositories
{
    using Domain;
    using System.Threading.Tasks;

    public interface IQuizzesRepository
    {
        Task<Quiz> GetByIdAsync(int quizId);

        Task<QuizzesPaged> GetByTopicPagedAsync(
            int topicId,
            int startIndex,
            int numberOfItems);

        Task<QuizzesPaged> GetAllByUserPagedAsync(
            int userId,
            int startIndex,
            int numberOfItems);

        Task<QuizzesPaged> GetPublicByUserPagedAsync(
            int userId,
            int startIndex,
            int numberOfItems);

        Task<QuizzesPaged> GetPublicPagedAsync(
            int startIndex,
            int numberOfItems);

        Task InsertAsync(Quiz quiz);

        Task DeleteByIdAsync(int quizId);

        Task DeleteByUserIdAsync(int userId, bool keepPublic);
    }
}
