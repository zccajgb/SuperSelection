namespace DomainModel.Infrastructure
{
    using System.Security.Claims;
    using DomainModel.Models;

    public interface ITokenManager
    {
        string GenerateToken(User user);

        ClaimsPrincipal GetPrincipal(string token);

        (string username, string id, string role) ValidateToken(string token);
    }
}