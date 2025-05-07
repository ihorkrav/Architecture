
namespace BookStore.Core.Entities;
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public List<Order> Orders { get; set; } = new();
}
