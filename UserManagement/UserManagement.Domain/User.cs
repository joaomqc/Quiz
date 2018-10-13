namespace UserManagement.Domain
{
    public class User
    {
        public static User CreateNewUser(
            string email,
            string username,
            string password)
        {
            return new User(
                0,
                email,
                username,
                password);
        }

        public static User CreateUser(
            int id,
            string email,
            string username)
        {
            return new User(
                id,
                email,
                username,
                null);
        }

        public User(
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
