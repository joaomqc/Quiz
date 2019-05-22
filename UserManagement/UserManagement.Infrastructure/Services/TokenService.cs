namespace UserManagement.Infrastructure.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Application.Services;
    using Domain;
    using Microsoft.IdentityModel.Tokens;

    public class TokenService : ITokenService
    {
        private readonly int _expiryTime;
        private readonly string _audience;
        private readonly string _issuer;
        private readonly string _signingKey;

        public TokenService(
            int expiryTime,
            string audience,
            string issuer,
            string signingKey)
        {
            _expiryTime = expiryTime;
            _audience = audience ??
                throw new ArgumentNullException(nameof(audience));
            _issuer = issuer ??
                throw new ArgumentNullException(nameof(issuer));
            _signingKey = signingKey ??
                throw new ArgumentNullException(nameof(signingKey));
        }

        public Token GetToken(Guid userId)
        {
            var expirySeconds = _expiryTime;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(expirySeconds),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey)),
                    SecurityAlgorithms.HmacSha256)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(accessToken, expirySeconds);
        }
    }
}
