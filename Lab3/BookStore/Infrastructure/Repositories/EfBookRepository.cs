namespace BookStore.Infrastructure.Repositories;
using BookStore.Core.Entities;
using BookStore.Core.Ports;
using BookStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
 public class EfBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public EfBookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }
    }