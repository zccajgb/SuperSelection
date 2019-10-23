namespace DomainModel
{
    using DomainModel.Models;

    public interface ICreateNewUserService
    {
        UserView CreateNewUser(string username, string password, string firstName, string lastName);
    }
}