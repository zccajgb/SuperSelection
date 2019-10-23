namespace DomainModel.Infrastructure
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using DomainModel.Models;
    using Microsoft.IdentityModel.Tokens;

    public class TokenManager : ITokenManager
    {
        // https://www.red-gate.com/simple-talk/dotnet/net-development/jwt-authentication-microservices-net/

        private readonly string secret = "bNgqblE+ZUjUyBxBreVPBGeXFJRFbsxfY76lW0zHilrvq+tNOYFAir5ZxlEVb6YSmOspHfWBEV7MbwJAkFSXYQ==";
        private readonly int expiry = 30;

        public TokenManager(string secret, int expiry)
        {
            this.secret = secret;
            this.expiry = expiry;
        }

        public string GenerateToken(User user)
        {
            if (user == null)
            {
                var message = "User is null";
                throw new ArgumentNullException(message);
            }

            byte[] key = Convert.FromBase64String(this.secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                      new Claim(ClaimTypes.Name, user.Username),
                      new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                      new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                }),

                Expires = DateTime.UtcNow.AddMinutes(this.expiry),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "borrowed code")]
        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                if (jwtToken == null)
                {
                    return null;
                }

                byte[] key = Convert.FromBase64String(this.secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }

        public (string username, string id, string role) ValidateToken(string token)
        {
            ClaimsPrincipal principal = this.GetPrincipal(token);
            if (principal == null)
            {
                throw new NullReferenceException("Principal Not Found");
            }

            ClaimsIdentity identity = (ClaimsIdentity)principal.Identity;

            var username = identity.FindFirst(ClaimTypes.Name).Value;
            var id = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var role = identity.FindFirst(ClaimTypes.Role).Value;
            return (username, id, role);
        }
    }
}
