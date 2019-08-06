namespace QuizManagement.Application.Repositories
{
    using System;
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
            Guid userId,
            int startIndex,
            int numberOfItems);

        Task<QuizzesPaged> GetPublicByUserPagedAsync(
            Guid userId,
            int startIndex,
            int numberOfItems);

        Task<QuizzesPaged> GetPublicPagedAsync(
            int startIndex,
            int numberOfItems);

        Task InsertAsync(Quiz quiz);

        Task DeleteByIdAsync(int quizId);

        Task DeleteByUserIdAsync(
            Guid userId,
            bool keepPublic);
    }
}
