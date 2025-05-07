namespace BookStore.Core.Services;
using BookStore.Core.Entities;
using BookStore.Core.Ports;


    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks() => _bookRepository.GetAllBooks();

        public Book GetById(int id) => _bookRepository.GetById(id);
    }

