namespace DomainModel
{
    using DomainModel.Models;

    public interface ILoginService
    {
        UserView Login(string username, string password);
    }
}