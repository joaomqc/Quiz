namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class RemoveAllQuizzesByUserParameters : IParameter
    {
        public RemoveAllQuizzesByUserParameters(
            int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
