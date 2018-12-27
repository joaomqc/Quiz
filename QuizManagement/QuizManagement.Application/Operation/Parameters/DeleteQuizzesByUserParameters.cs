namespace QuizManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class DeleteQuizzesByUserParameters : IParameter
    {
        public DeleteQuizzesByUserParameters(
            int userId,
            bool keepPublic)
        {
            UserId = userId;
            KeepPublic = keepPublic;
        }

        public int UserId { get; }
        public bool KeepPublic { get; }
    }
}
