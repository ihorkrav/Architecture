namespace BookStore.Infrastructure.Repositories;
using BookStore.Core.Entities;
using BookStore.Core.Ports;
using BookStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

 public class EfOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public EfOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public List<Order> GetOrdersForUser(int userId)
        {
            return _context.Orders
                .Include(o => o.Book)
                .Where(o => o.UserId == userId)
                .ToList();
        }
    }