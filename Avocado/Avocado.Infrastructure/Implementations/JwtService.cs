﻿namespace Avocado.Infrastructure.Implementations
{
    using Avocado.Application.Authentication.Model;
    using Avocado.Application.Interfaces;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;

    public class JwtService : IJwtService
    {
        private readonly JwtSettingsModel _settings;
        private readonly byte[] _key;
        private JwtSecurityTokenHandler _handler;


        public JwtService(IOptions<JwtSettingsModel> settings)
        {
            _settings = settings.Value;
            _key = Base64UrlEncoder.DecodeBytes(_settings.Key);
            _handler = new JwtSecurityTokenHandler();
        }

        public JwtTokenModel GenerateJwtToken(string email, Guid id, bool isAdmin = false, bool isReset = false)
        {
            var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.UserData, id.ToString())
                });

            if (isAdmin)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            }
            else if (isReset)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, "ResetPassword"));
            }
            else
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, "User"));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            var result = _handler.CreateToken(tokenDescriptor);

            return new JwtTokenModel { Token = _handler.WriteToken(result), ValidTo = result.ValidTo, Email = email, Status = "success" };
        }

        public bool ValidateStringToken(string token)
        {
            var parameters = new TokenValidationParameters
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(_key)
            };

            _handler.ValidateToken(token, parameters, out _);

            return true;
        }

        public Guid GetUserIdFromToken(string token)
        {
            var secToken = _handler.ReadJwtToken(token);
            var claim = secToken.Claims.FirstOrDefault(x => x.Type.Equals("userdata") || x.Type.Equals(ClaimTypes.UserData));

            return Guid.Parse(claim.Value);
        }

        public bool IsResetPasswordToken(string token)
        {
            var jwtToken = _handler.ReadJwtToken(token);
            var claim = jwtToken.Claims.Where(x => x.Type.Equals("role") || x.Type.Equals(ClaimTypes.Role)).ToList();

            return claim.FirstOrDefault(x => x.Value.Equals("ResetPassword")) != null;
        }
    }
}
