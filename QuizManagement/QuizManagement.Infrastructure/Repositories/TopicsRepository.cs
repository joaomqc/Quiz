namespace QuizManagement.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using QuizManagement.Domain;
    using QuizManagement.Application.Repositories;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using System.Linq;

    public class TopicsRepository : ITopicsRepository
    {
        private readonly QuizContext _context;

        public TopicsRepository(QuizContext quizContext)
        {
            _context = quizContext
                       ?? throw new ArgumentNullException(nameof(quizContext));
        }

        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            var topics =
                await _context.Topics
                    .ToListAsync()
                    .ConfigureAwait(false);

            return topics
                .Select(topic => new Topic(
                    id: topic.Id,
                    name: topic.Name,
                    description: topic.Description,
                    imageUrl: topic.ImageUrl))
                .ToList();
        }

        public async Task<Topic> GetByIdAsync(int topicId)
        {
            var topic =
                await _context.Topics
                    .FirstOrDefaultAsync(t => t.Id == topicId)
                    .ConfigureAwait(false);

            return new Topic(
                id: topic.Id,
                name: topic.Name,
                description: topic.Description,
                imageUrl: topic.ImageUrl);
        }
    }
}
