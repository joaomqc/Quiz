namespace QuizManagement.Rpc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Operation.Parameters;
    using Application.Operation.Results;
    using Domain;
    using Grpc.Core;
    using Shared.Contracts.Common;
    using Shared.Contracts.QuizManagement.Quizzes;
    using Shared.Executors;

    public class QuizzesController : QuizzesService.QuizzesServiceBase
    {
        private readonly IExecutor _executor;

        public QuizzesController(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public override async Task<GetQuizzesPagedResult> GetQuizzesPaged(
            GetPagedParameter request,
            ServerCallContext context)
        {
            var quizzes =
                await _executor
                    .ExecuteAsync<GetQuizzesPagedParameters, GetQuizzesPagedResults>(
                        new GetQuizzesPagedParameters(
                            request.StartIndex,
                            request.ItemCount))
                    .ConfigureAwait(false);

            return new GetQuizzesPagedResult
            {
                PageInfo = new GetPagedResult
                {
                    EndIndex = quizzes.EndIndex,
                    ItemCount = quizzes.ItemCount,
                    StartIndex = quizzes.StartIndex,
                    TotalCount = quizzes.TotalCount
                },
                Quizzes = { GetQuizzes(quizzes.List) }
            };
        }

        public override async Task<GetQuizByIdResult> GetQuiz(
            GetQuizByIdParameter request,
            ServerCallContext context)
        {
            var quiz =
                await _executor
                    .ExecuteAsync<GetQuizByIdParameters, GetQuizByIdResults>(
                        new GetQuizByIdParameters(request.QuizId))
                    .ConfigureAwait(false);

            return new GetQuizByIdResult
            {
                CreationTimestamp = quiz.CreationTimestamp.Ticks,
                IsPublic = quiz.IsPublic,
                Name = quiz.Name,
                Questions = { GetQuestions(quiz.Questions) },
                QuizId = quiz.Id,
                Topic = new TopicResult
                {
                    TopicId = quiz.Topic.Id,
                    Name = quiz.Topic.Name,
                    ImageUrl = quiz.ImageUrl
                },
                UserId = quiz.UserId.ToString(),
                ImageUrl = quiz.ImageUrl
            };
        }

        public override async Task<GetQuizzesPagedResult> GetQuizzesByUserPaged(
            GetQuizzesByUserPagedParameter request,
            ServerCallContext context)
        {
            var quizzes =
                await _executor
                    .ExecuteAsync<GetAllQuizzesByUserPagedParameters, GetAllQuizzesByUserPagedResults>(
                        new GetAllQuizzesByUserPagedParameters(
                            userId: Guid.Parse(request.UserId),
                            startIndex: request.PageInfo.StartIndex,
                            numberOfItems: request.PageInfo.ItemCount))
                    .ConfigureAwait(false);

            return new GetQuizzesPagedResult
            {
                PageInfo = new GetPagedResult
                {
                    EndIndex = quizzes.EndIndex,
                    ItemCount = quizzes.ItemCount,
                    StartIndex = quizzes.StartIndex,
                    TotalCount = quizzes.TotalCount
                },
                Quizzes = { GetQuizzes(quizzes.List) }
            };
        }

        public override async Task<GetQuizzesPagedResult> GetPublicQuizzesByUserPaged(
            GetQuizzesByUserPagedParameter request,
            ServerCallContext context)
        {
            var quizzes =
                await _executor
                    .ExecuteAsync<GetPublicQuizzesByUserPagedParameters, GetPublicQuizzesByUserPagedResults>(
                        new GetPublicQuizzesByUserPagedParameters(
                            userId: Guid.Parse(request.UserId),
                            startIndex: request.PageInfo.StartIndex,
                            numberOfItems: request.PageInfo.ItemCount))
                    .ConfigureAwait(false);

            return new GetQuizzesPagedResult
            {
                PageInfo = new GetPagedResult
                {
                    EndIndex = quizzes.EndIndex,
                    ItemCount = quizzes.ItemCount,
                    StartIndex = quizzes.StartIndex,
                    TotalCount = quizzes.TotalCount
                },
                Quizzes = { GetQuizzes(quizzes.List) }
            };
        }

        public override async Task<GetQuizzesPagedResult> GetQuizzesByTopicPaged(
            GetQuizzesByTopicPagedParameter request,
            ServerCallContext context)
        {
            var quizzes =
                await _executor
                    .ExecuteAsync<GetQuizzesByTopicPagedParameters, GetQuizzesByTopicPagedResults>(
                        new GetQuizzesByTopicPagedParameters(
                            topicId: request.TopicId,
                            startIndex: request.PageInfo.StartIndex,
                            numberOfItems: request.PageInfo.ItemCount))
                    .ConfigureAwait(false);

            return new GetQuizzesPagedResult
            {
                PageInfo = new GetPagedResult
                {
                    EndIndex = quizzes.EndIndex,
                    ItemCount = quizzes.ItemCount,
                    StartIndex = quizzes.StartIndex,
                    TotalCount = quizzes.TotalCount
                },
                Quizzes = { GetQuizzes(quizzes.List) }
            };
        }

        public override async Task<Empty> CreateQuiz(
            CreateQuizParameter request,
            ServerCallContext context)
        {
            await _executor
                .ExecuteAsync<CreateQuizParameters, CreateQuizResults>(
                    new CreateQuizParameters(
                        name: request.Name,
                        userId: Guid.Parse(request.UserId),
                        questions: request.Questions.Select(
                            question => Question.CreateNewQuestion(
                                text: question.Text,
                                isMultipleChoice: question.IsMultipleChoice,
                                answers: question.Answers.Select(
                                    answer => Answer.CreateNewAnswer(
                                        text: answer.Text,
                                        isCorrect: answer.IsCorrect)))),
                        topicId: request.TopicId,
                        isPublic: request.IsPublic,
                        imageUrl: request.ImageUrl))
                .ConfigureAwait(false);

            return new Empty();
        }

        public override async Task<Empty> DeleteQuiz(
            DeleteQuizParameter request,
            ServerCallContext context)
        {
            await _executor
                .ExecuteAsync<DeleteQuizByIdParameters, DeleteQuizByIdResults>(
                    new DeleteQuizByIdParameters(request.QuizId))
                .ConfigureAwait(false);

            return new Empty();
        }

        public override async Task<Empty> DeleteQuizzesByUser(
            DeleteQuizzesByUserParameter request,
            ServerCallContext context)
        {
            await _executor
                .ExecuteAsync<DeleteQuizzesByUserParameters, DeleteQuizzesByUserResults>(
                    new DeleteQuizzesByUserParameters(
                        userId: Guid.Parse(request.UserId),
                        keepPublic: request.KeepPublic))
                .ConfigureAwait(false);

            return new Empty();
        }

        private IEnumerable<QuizResult> GetQuizzes(IEnumerable<QuizDetails> quizzes)
        {
            return quizzes.Select(
                quiz => new QuizResult
                {
                    CreationTimestamp = quiz.CreationTimestamp.Ticks,
                    IsPublic = quiz.IsPublic,
                    Name = quiz.Name,
                    QuizId = quiz.Id,
                    Topic = new TopicResult
                    {
                        Name = quiz.Topic.Name,
                        TopicId = quiz.Topic.Id,
                        ImageUrl = quiz.ImageUrl
                    },
                    UserId = quiz.UserId.ToString(),
                    ImageUrl = quiz.ImageUrl
                });
        }

        private IEnumerable<QuestionResult> GetQuestions(IEnumerable<Question> questions)
        {
            return questions.Select(
                question => new QuestionResult
                {
                    Answers =
                    {
                        question.Answers.Select(
                            answer => new AnswerResult
                            {
                                AnswerId = answer.Id,
                                IsCorrect = answer.IsCorrect,
                                Text = answer.Text
                            })
                    },
                    IsMultipleChoice = question.IsMultipleChoice,
                    QuestionId = question.Id,
                    Text = question.Text
                });
        }
    }
}
