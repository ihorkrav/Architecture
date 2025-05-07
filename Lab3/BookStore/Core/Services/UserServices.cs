namespace BookStore.Core.Services;
using BookStore.Core.Entities;
using BookStore.Core.Ports;
public class UserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public void Register(User user) => _repo.Register(user);
    public User Login(string username, string password) => _repo.Login(username, password);
    public User GetProfile(int userId) => _repo.GetUserWithOrders(userId);
}
