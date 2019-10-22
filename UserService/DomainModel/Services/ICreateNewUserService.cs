using DomainModel.Models;

namespace DomainModel
{
    public interface ICreateNewUserService
    {
        UserView CreateNewUser(string username, string password, string firstName, string lastName);
    }
}