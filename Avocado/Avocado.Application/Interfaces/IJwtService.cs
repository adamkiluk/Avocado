namespace Avocado.Application.Interfaces
{
    using Avocado.Application.Authentication.Model;
    using System;

    public interface IJwtService
    {
        JwtTokenModel GenerateJwtToken(string email, Guid id, bool isAdmin = false, bool isReset = false);
        bool ValidateStringToken(string token);
        Guid GetUserIdFromToken(string token);
        bool IsResetPasswordToken(string token);
    }
}