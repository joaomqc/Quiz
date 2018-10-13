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

        public async Task<IEnumerable<Topic>> GetAllAsync(
            CancellationToken ct = default(CancellationToken))
        {
            var topics =
                await _context.Topics
                    .ToListAsync(ct)
                    .ConfigureAwait(false);

            return topics
                .Select(topic => new Topic(
                    topic.Id,
                    topic.Name,
                    topic.Description))
                .ToList();
        }

        public async Task<Topic> GetByIdAsync(
            int topicId,
            CancellationToken ct = default(CancellationToken))
        {
            var topic =
                await _context.Topics
                    .FirstOrDefaultAsync(t => t.Id == topicId, ct)
                    .ConfigureAwait(false);

            return new Topic(
                topic.Id,
                topic.Name,
                topic.Description);
        }
    }
}
