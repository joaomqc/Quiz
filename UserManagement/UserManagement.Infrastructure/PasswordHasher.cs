namespace UserManagement.Infrastructure
{
    using Application;
    using BCrypt.Net;

    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.EnhancedHashPassword(password);
        }

        public bool VerifyPassword(string providedPassword, string hashedPassword)
        {
            return BCrypt.EnhancedVerify(providedPassword, hashedPassword);
        }
    }
}
