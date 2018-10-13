namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class RemoveQuizByIdParameters : IParameter
    {
        public RemoveQuizByIdParameters(
            int quizId)
        {
            QuizId = quizId;
        }

        public int QuizId { get; }
    }
}
