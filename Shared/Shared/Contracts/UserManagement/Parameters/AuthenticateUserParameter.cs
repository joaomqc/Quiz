namespace Shared.Contracts.UserManagement.Parameters
{
    public class AuthenticateUserParameter
    {
        public AuthenticateUserParameter(
            string userName,
            string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }
}
