namespace QuizManagement.Infrastructure.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Repositories;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class QuizzesRepository : IQuizzesRepository
    {
        private readonly QuizContext _context;

        public QuizzesRepository(QuizContext quizContext)
        {
            _context = quizContext
                       ?? throw new ArgumentNullException(nameof(quizContext));
        }

        public async Task<Quiz> GetByIdAsync(int quizId)
        {
            var quiz =
                await (
                    from q in _context.Quizzes
                    where q.Id == quizId
                    select new
                    {
                        Id = q.Id,
                        Name = q.Name,
                        CreationTimestamp = q.CreationTimestamp,
                        UserId = q.UserId,
                        Questions =
                            from qu in _context.Questions
                            where q.Id == qu.QuizId
                            select new
                            {
                                Id = qu.Id,
                                Text = qu.Text,
                                IsMultipleChoice = qu.IsMultipleChoice,
                                Answers =
                                    from a in _context.Answers
                                    where qu.Id == a.QuestionId
                                    select new
                                    {
                                        Id = a.Id,
                                        Text = a.Text,
                                        IsCorrect = a.IsCorrect
                                    }
                            },
                        Comments =
                            from c in _context.Comments
                            where q.Id == c.QuizId
                            select new
                            {
                                Id = c.Id,
                                Text = c.Text,
                                CreationTimestamp = c.CreationTimestamp,
                                UserId = c.UserId
                            },
                        Topic = q.Topic,
                        IsPublic = q.IsPublic,
                        ImageUrl = q.ImageUrl
                    })
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);

            var questions =
                await quiz.Questions.Select(
                    question => new Question(
                        question.Id,
                        question.Text,
                        question.IsMultipleChoice,
                        question.Answers.Select(
                            answer => new Answer(
                                answer.Id,
                                answer.Text,
                                answer.IsCorrect))
                            .ToList()))
                    .ToListAsync()
                    .ConfigureAwait(false);

            var comments =
                await quiz.Comments.Select(
                    comment => new Comment(
                        comment.Id,
                        comment.Text,
                        comment.CreationTimestamp,
                        comment.UserId))
                    .ToListAsync()
                    .ConfigureAwait(false);

            return new Quiz(
                id: quiz.Id,
                name: quiz.Name,
                creationTimestamp: quiz.CreationTimestamp,
                userId: quiz.UserId,
                questions: questions,
                topicId: quiz.Topic.Id,
                isPublic: quiz.IsPublic,
                comments: comments,
                imageUrl: quiz.ImageUrl);
        }

        public async Task<QuizzesPaged> GetByTopicPagedAsync(
            int topicId,
            int startIndex,
            int numberOfItems)
        {
            return await GetPagedAsync(
                startIndex: startIndex,
                numberOfItems: numberOfItems,
                filter: quiz => quiz.Topic.Id == topicId && quiz.IsPublic)
                .ConfigureAwait(false);
        }

        public async Task<QuizzesPaged> GetPublicPagedAsync(
            int startIndex,
            int numberOfItems)
        {
            return await GetPagedAsync(
                startIndex: startIndex,
                numberOfItems: numberOfItems,
                filter: quiz => quiz.IsPublic)
                .ConfigureAwait(false);
        }

        public async Task<QuizzesPaged> GetAllByUserPagedAsync(
            Guid userId,
            int startIndex,
            int numberOfItems)
        {
            return await GetPagedAsync(
                startIndex: startIndex,
                numberOfItems: numberOfItems,
                filter: quiz => quiz.UserId == userId)
                .ConfigureAwait(false);
        }

        public async Task<QuizzesPaged> GetPublicByUserPagedAsync(
            Guid userId,
            int startIndex,
            int numberOfItems)
        {
            return await GetPagedAsync(
                startIndex: startIndex,
                numberOfItems:numberOfItems,
                filter: quiz => quiz.UserId == userId && quiz.IsPublic)
                .ConfigureAwait(false);
        }

        private async Task<QuizzesPaged> GetPagedAsync(
            int startIndex,
            int numberOfItems,
            Expression<Func<Entities.Quiz, bool>> filter)
        {
            var quizzes =
                await _context.Quizzes
                    .Where(filter)
                    .Skip(startIndex)
                    .Take(numberOfItems)
                    .ToListAsync()
                    .ConfigureAwait(false);

            var total =
                await _context.Quizzes
                    .CountAsync()
                    .ConfigureAwait(false);

            return new QuizzesPaged(
                list: quizzes.Select(
                    quiz => new QuizDetails(
                        id: quiz.Id,
                        name: quiz.Name,
                        creationTimestamp: quiz.CreationTimestamp,
                        userId: quiz.UserId,
                        topic: new TopicDetails(
                            id: quiz.Topic.Id,
                            name: quiz.Topic.Name,
                            imageUrl: quiz.Topic.ImageUrl), 
                        isPublic: quiz.IsPublic,
                        imageUrl: quiz.ImageUrl))
                    .ToList(),
                totalCount: total,
                itemCount: quizzes.Count,
                startIndex: startIndex,
                endIndex: startIndex + quizzes.Count);
        }
        
        public async Task InsertAsync(Quiz quiz)
        {
            var quizToAdd =
                new Entities.Quiz
                {
                    Name = quiz.Name,
                    CreationTimestamp = quiz.CreationTimestamp,
                    UserId = quiz.UserId,
                    IsPublic = quiz.IsPublic,
                    TopicId = quiz.TopicId,
                    ImageUrl = quiz.ImageUrl
                };
            
            var questions =
                quiz.Questions
                    .Select(question => new Entities.Question
                    {
                        Text = question.Text,
                        IsMultipleChoice = question.IsMultipleChoice,
                        QuizId = quiz.Id
                    }).ToList();

            var answers =
                quiz.Questions
                    .SelectMany(question => question.Answers.Select(answer => new
                    {
                        QuestionId = question.Id,
                        Answer = answer
                    }))
                    .Select(answer => new Entities.Answer
                    {
                        Text = answer.Answer.Text,
                        IsCorrect = answer.Answer.IsCorrect,
                        QuestionId = answer.QuestionId
                    }).ToList();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try {

                    await _context.Quizzes
                        .AddAsync(quizToAdd)
                        .ConfigureAwait(false);

                    await _context.Questions
                        .AddRangeAsync(questions)
                        .ConfigureAwait(false);

                    await _context.Answers
                        .AddRangeAsync(answers)
                        .ConfigureAwait(false);
             
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Dispose();
                }
            }
        }

        public async Task DeleteByIdAsync(int quizId)
        {
            var quizToRemove =
                await _context.Quizzes
                    .FirstOrDefaultAsync(quiz => quiz.Id == quizId)
                    .ConfigureAwait(false);

            if (quizToRemove != null)
            {
                _context.Quizzes.Remove(quizToRemove);

                await _context
                    .SaveChangesAsync()
                    .ConfigureAwait(false);
            }
        }

        public async Task DeleteByUserIdAsync(
            Guid userId,
            bool keepPublic)
        {
            var quizzesToRemove =
                _context.Quizzes
                    .Where(quiz => quiz.UserId == userId && (!keepPublic || !quiz.IsPublic));

            _context.Quizzes.RemoveRange(quizzesToRemove);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
