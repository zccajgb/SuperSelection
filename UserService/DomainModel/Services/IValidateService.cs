using System;

namespace DomainModel
{
    public interface IValidateService
    {
        int GetUserRole(string token);
        Guid Validate(string token);
        Guid Validate(string token, string username);
    }
}