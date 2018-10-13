namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class RemovePrivateQuizzesByUserParameters : IParameter
    {
        public RemovePrivateQuizzesByUserParameters(
            int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
