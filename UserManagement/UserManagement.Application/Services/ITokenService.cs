namespace UserManagement.Application.Services
{
    using System;
    using Domain;

    public interface ITokenService
    {
        Token GetToken(Guid userId);
    }
}
