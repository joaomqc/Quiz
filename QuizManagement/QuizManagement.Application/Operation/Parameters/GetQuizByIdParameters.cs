namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class GetQuizByIdParameters : IParameter
    {
        public GetQuizByIdParameters(
            int quizId)
        {
            QuizId = quizId;
        }

        public int QuizId { get; }
    }
}
