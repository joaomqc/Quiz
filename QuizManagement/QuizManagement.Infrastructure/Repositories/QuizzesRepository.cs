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
                        IsPublic = q.IsPublic
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
                quiz.Id,
                quiz.Name,
                quiz.CreationTimestamp,
                quiz.UserId,
                questions,
                quiz.Topic.Id,
                quiz.IsPublic,
                comments);
        }

        public async Task<QuizzesPaged> GetByTopicPagedAsync(
            int topicId,
            int startIndex,
            int numberOfItems)
        {
            return await GetPagedAsync(
                startIndex,
                numberOfItems,
                quiz => quiz.Topic.Id == topicId && quiz.IsPublic)
                .ConfigureAwait(false);
        }

        public async Task<QuizzesPaged> GetPublicPagedAsync(
            int startIndex,
            int numberOfItems)
        {
            return await GetPagedAsync(
                startIndex,
                numberOfItems,
                quiz => quiz.IsPublic)
                .ConfigureAwait(false);
        }

        public async Task<QuizzesPaged> GetAllByUserPagedAsync(
            int userId,
            int startIndex,
            int numberOfItems)
        {
            return await GetPagedAsync(
                startIndex,
                numberOfItems,
                quiz => quiz.UserId == userId)
                .ConfigureAwait(false);
        }

        public async Task<QuizzesPaged> GetPublicByUserPagedAsync(
            int userId,
            int startIndex,
            int numberOfItems)
        {
            return await GetPagedAsync(
                startIndex,
                numberOfItems,
                quiz => quiz.UserId == userId && quiz.IsPublic)
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
                quizzes.Select(
                    quiz => new QuizDetails(
                        quiz.Id,
                        quiz.Name,
                        quiz.CreationTimestamp,
                        quiz.UserId,
                        new TopicDetails(
                            quiz.Topic.Id,
                            quiz.Topic.Name), 
                        quiz.IsPublic))
                    .ToList(),
                total,
                numberOfItems,
                startIndex,
                startIndex + numberOfItems);
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
                    TopicId = quiz.TopicId
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

        public async Task DeleteByUserIdAsync(int userId, bool keepPublic)
        {
            var quizzesToRemove =
                _context.Quizzes
                    .Where(quiz => !quiz.IsPublic || !keepPublic);

            _context.Quizzes.RemoveRange(quizzesToRemove);

            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
