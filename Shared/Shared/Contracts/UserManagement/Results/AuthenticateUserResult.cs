namespace Shared.Contracts.UserManagement.Results
{
    public class AuthenticateUserResult
    {
        public AuthenticateUserResult(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
