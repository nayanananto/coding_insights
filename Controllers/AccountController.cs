using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using theParodyJournal.Models;

public class AccountController : Controller
{
    private readonly UserContext _context;

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();  
        return RedirectToAction("Index", "Home");  
    }

    public AccountController(UserContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Login(IFormCollection form)
    {
        string email = form["email"];
        string password = form["password"];

        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            TempData["SuccessMessage"] = $"Welcome, {user.Name}!";
            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Index", "Home");  
        }
        else
        {
            TempData["ErrorMessage"] = "Invalid email or password!";
            return View();
        }
    }
    public IActionResult ForgotPassword()
    {
        return View(); 
    }


    
    [HttpGet]

    public IActionResult Signup()
    {
        return View();  
    }

    
    [HttpPost]
    public IActionResult Signup(IFormCollection form)
    {
        string username = form["username"];
        string email = form["email"];
        string phone = form["phone"];
        string password = form["password"];
        string confirmPassword = form["confirmPassword"];
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);
        if (existingUser != null)
        {
            TempData["ErrorMessage"] = "Email is already in use!";
            return View();
        }

        if (password != confirmPassword)
        {
            TempData["ErrorMessage"] = "Passwords do not match!";
            return View();
        }
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new UserDB
        {
            Name = username,
            Email = email,
            Password = hashedPassword
        };

        _context.Users.Add(user);
        _context.SaveChanges();


        TempData["SuccessMessage"] = "Account created successfully!";
        return RedirectToAction("Login");
    }
}
