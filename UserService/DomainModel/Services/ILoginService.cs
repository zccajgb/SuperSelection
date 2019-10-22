using DomainModel.Models;

namespace DomainModel
{
    public interface ILoginService
    {
        UserView Login(string username, string password);
    }
}