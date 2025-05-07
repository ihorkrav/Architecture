using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Core.Entities;
using BookStore.Core.Services;

namespace BookStore.Controllers;
public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // Register Page (GET)
    [HttpGet]
    public IActionResult Register() => View();

    // Register Action (POST)
    [HttpPost]
public IActionResult Register(User user)
{
    if (ModelState.IsValid)
    {
        _userService.Register(user);
        var loggedInUser = _userService.Login(user.Username, user.PasswordHash);
        if (loggedInUser != null)
        {
            HttpContext.Session.SetInt32("UserId", loggedInUser.Id);
            return RedirectToAction("Index", "Book"); // Redirect to Books after register
        }
        return RedirectToAction("Login");
    }
    return View(user);
}

    // Login Page (GET)
    [HttpGet]
    public IActionResult Login() => View();

    // Login Action (POST)
    [HttpPost]
public IActionResult Login(string username, string password)
{
    var user = _userService.Login(username, password);
    if (user != null)
    {
        HttpContext.Session.SetInt32("UserId", user.Id);
        return RedirectToAction("Index", "Book"); // Redirect to Books after login
    }

    ViewBag.ErrorMessage = "Invalid username or password.";
    return View();
}

    // Profile Page (GET)
    public IActionResult Profile()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        var user = _userService.GetProfile(userId.Value);
        return View(user);
    }
}
