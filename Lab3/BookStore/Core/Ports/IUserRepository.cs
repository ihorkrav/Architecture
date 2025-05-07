namespace BookStore.Core.Ports;
using BookStore.Core.Entities;
public interface IUserRepository
{
    void Register(User user);
    User Login(string username, string password);
    User GetUserWithOrders(int userId);
}
