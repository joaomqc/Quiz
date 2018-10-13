namespace UserManagement.Application.Operation.Results
{
    using Shared.Operation;

    public class AuthenticateUserResults : IResult
    {
        public AuthenticateUserResults(
            bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
        }

        public bool IsAuthenticated { get; }
    }
}
