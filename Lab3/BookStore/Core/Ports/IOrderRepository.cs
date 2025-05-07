namespace BookStore.Core.Ports;
using BookStore.Core.Entities;

public interface IOrderRepository
{
    void CreateOrder(Order order);
    List<Order> GetOrdersForUser(int userId);
}
