namespace UserManagement.Domain
{
    public class User
    {
        public User(
            string email,
            string username)
        {
            Email = email;
            Username = username;
        }
        
        public string Email { get; }
        public string Username { get; }
    }
}
