namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class DeleteQuizByIdParameters : IParameter
    {
        public DeleteQuizByIdParameters(
            int quizId)
        {
            QuizId = quizId;
        }

        public int QuizId { get; }
    }
}
