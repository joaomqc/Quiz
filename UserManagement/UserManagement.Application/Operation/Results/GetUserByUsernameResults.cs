namespace UserManagement.Application.Operation.Results
{
    using System;
    using Shared.Operation;

    public class GetUserByUsernameResults : IResult
    {
        public GetUserByUsernameResults(
            string username,
            string email)
        {
            Username = username;
            Email = email;
        }

        public string Username { get; }
        public string Email { get; }
    }
}
