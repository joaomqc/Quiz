namespace UserManagement.Application.Operation.Results
{
    using Domain;
    using Shared.Operation;

    public class AuthenticateUserResults : IResult
    {
        public AuthenticateUserResults(
            Token token)
        {
            Token = token;
        }

        public Token Token { get; }
    }
}
