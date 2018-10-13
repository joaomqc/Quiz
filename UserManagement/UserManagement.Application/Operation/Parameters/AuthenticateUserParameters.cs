namespace UserManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class AuthenticateUserParameters : IParameter
    {
        public AuthenticateUserParameters(
            string username,
            string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }
        public string Password { get; }
    }
}
