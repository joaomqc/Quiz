namespace QuizManagement.Application.Repositories
{
    using Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITopicsRepository
    {
        Task<IEnumerable<Topic>> GetAllAsync();

        Task<Topic> GetByIdAsync(int topicId);
    }
}
