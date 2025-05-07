using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Core.Entities;
using BookStore.Core.Services;


public class BookController : Controller
{
    private readonly BookService _bookService;
    private readonly OrderService _orderService;

    public BookController(BookService bookService, OrderService orderService)
    {
        _bookService = bookService;
        _orderService = orderService;
    }

    public IActionResult Index()
    {
        var books = _bookService.GetAllBooks();
        return View(books);
    }

    [HttpPost]
public IActionResult Order(int id)
{
    var userId = HttpContext.Session.GetInt32("UserId");
    if (userId == null)
        return RedirectToAction("Login", "User");

    _orderService.OrderBook(userId.Value, id);
    return RedirectToAction("Profile", "User");
}

}
