namespace UserManagement.Application.Operation.Results
{
    using Shared.Operation;

    public class GetUserByIdResults : IResult
    {
        public GetUserByIdResults(
            int id,
            string email,
            string username,
            string password)
        {
            Id = id;
            Email = email;
            Username = username;
            Password = password;
        }

        public int Id { get; }
        public string Email { get; }
        public string Username { get; }
        public string Password { get; }
    }
}
