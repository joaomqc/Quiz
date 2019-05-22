namespace UserManagement.Domain
{
    public class Token
    {
        public Token(
            string accessToken,
            int expiresIn)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }

        public string AccessToken { get; }

        public int ExpiresIn { get; }
    }
}
