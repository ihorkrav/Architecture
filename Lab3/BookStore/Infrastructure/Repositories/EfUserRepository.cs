// File: BookStore.Infrastructure.Adapters.EfUserRepository.cs
using BookStore.Core.Entities;
using BookStore.Core.Ports;
using Microsoft.EntityFrameworkCore;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Adapters
{
    public class EfUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public EfUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Login(string username, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
        }

        public User GetUserWithOrders(int userId)
        {
            return _context.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.Book)
                .FirstOrDefault(u => u.Id == userId);
        }
    }
}
