namespace Shared.Contracts.QuizManagement
{
    using System;

    public class ServiceUrls
    {
        private readonly string _serviceUrl;

        public ServiceUrls(string serviceUrl)
        {
            _serviceUrl = serviceUrl
                          ?? throw new ArgumentNullException(nameof(serviceUrl));
        }

        private const string QuizUrl = "quizmanagement/quiz/{0}";

        private const string QuizzesUrl = "quizmanagement/quizzes?startIndex={0}&numberOfItems={1}";

        private const string QuizzesByUserUrl = "quizmanagement/quizzes/user/{0}?startIndex={1}&numberOfItems={2}";

        private const string PublicQuizzesByUserUrl = "quizmanagement/quizzes/user/{0}/public?startIndex={1}&numberOfItems={2}";

        private const string QuizzesByTopicUrl = "quizmanagement/quizzes/topic/{0}?startIndex={1}&numberOfItems={2}";

        private const string CreateQuizUrl = "quizmanagement/quizzes";

        private const string RemoveQuizzesByUserUrl = "quizmanagement/quizzes/user/{0}";

        private const string RemovePrivateQuizzesByUserUrl = "quizmanagement/quizzes/user/{0}/private";

        private const string TopicUrl = "quizmanagement/topics/{0}";

        private const string TopicsUrl = "quizmanagement/topics";

        public Uri GetQuizUrl(int quizId)
        {
            var partialUrl = string.Format(QuizUrl, quizId);
            return new Uri($"{_serviceUrl}/{partialUrl}");
        }

        public Uri GetQuizzesUrl(int startIndex, int numberOfItems)
        {
            var partialUrl = string.Format(QuizzesUrl, startIndex, numberOfItems);
            return new Uri($"{_serviceUrl}/{partialUrl}");
        }

        public Uri GetQuizzesByUserUrl(
            int userId,
            int startIndex,
            int numberOfItems)
        {
            var partialUrl = string.Format(QuizzesByUserUrl, userId, startIndex, numberOfItems);
            return new Uri($"{_serviceUrl}/{partialUrl}");
        }

        public Uri GetPublicQuizzesByUserUrl(
            int userId,
            int startIndex,
            int numberOfItems)
        {
            var partialUrl = string.Format(PublicQuizzesByUserUrl, userId, startIndex, numberOfItems);
            return new Uri($"{_serviceUrl}/{partialUrl}");
        }

        public Uri GetQuizzesByTopicUrl(
            int topicId,
            int startIndex,
            int numberOfItems)
        {
            var partialUrl = string.Format(QuizzesByTopicUrl, topicId, startIndex, numberOfItems);
            return new Uri($"{_serviceUrl}/{partialUrl}");
        }

        public Uri GetCreateQuizUrl()
        {
            return new Uri($"{_serviceUrl}/{CreateQuizUrl}");
        }

        public Uri GetRemoveQuizzesByUserUrl(int userId)
        {
            var partialUrl = string.Format(RemoveQuizzesByUserUrl, userId);
            return new Uri($"{_serviceUrl}/{partialUrl}");
        }

        public Uri GetRemovePrivateQuizzesByUserUrl(int userId)
        {
            var partialUrl = string.Format(RemovePrivateQuizzesByUserUrl, userId);
            return new Uri($"{_serviceUrl}/{partialUrl}");
        }

        public Uri GetTopicUrl(int topicId)
        {
            var partialUrl = string.Format(TopicUrl, topicId);
            return new Uri($"{_serviceUrl}/{partialUrl}");
        }

        public Uri GetTopicsUrl()
        {
            return new Uri($"{_serviceUrl}/{TopicsUrl}");
        }
    }
}
