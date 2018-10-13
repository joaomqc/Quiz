namespace UserManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class RegisterUserParameters : IParameter
    {
        public RegisterUserParameters(
            string email,
            string username,
            string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }

        public string Email { get; }
        public string Username { get; }
        public string Password { get; }

    }
}
