namespace UserManagement.Application.Operation.Results
{
    using Shared.Operation;

    public class GetUserByExternalIdResults : IResult
    {
        public GetUserByExternalIdResults(
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
