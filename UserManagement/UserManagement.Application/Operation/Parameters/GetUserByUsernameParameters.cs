namespace UserManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class GetUserByUsernameParameters : IParameter
    {
        public GetUserByUsernameParameters(
            string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}
