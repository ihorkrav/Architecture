namespace BookStore.Core.Services;
using BookStore.Core.Entities;
using BookStore.Core.Ports;

 public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void OrderBook(int userId, int bookId)
        {
            var order = new Order
            {
                UserId = userId,
                BookId = bookId,
                OrderDate = DateTime.UtcNow
            };
            _orderRepository.CreateOrder(order);
        }
    }