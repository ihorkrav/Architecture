using Microsoft.AspNetCore.Mvc;
using BikeShop.Data;
using BikeShop.Models;

namespace BikeShop.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                 return RedirectToAction("Index","Bike");
            }

            return View(user);
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpGet]
public IActionResult Login()
{
    return View();
}

[HttpPost]
public IActionResult Login(string username, string password)
{
    var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

    if (user != null)
    {
        // Login successful - you can store user info in session here if needed
        return RedirectToAction("Index","Bike");
    }

    ViewBag.Error = "Invalid username or password";
    return View();
}

public IActionResult Welcome(string name)
{
    ViewBag.Username = name;
    return View();
}

    }
}
