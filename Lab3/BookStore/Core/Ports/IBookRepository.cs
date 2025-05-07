namespace BookStore.Core.Ports;
using BookStore.Core.Entities;

public interface IBookRepository
{
    List<Book> GetAllBooks();
    Book GetById(int id);
}
