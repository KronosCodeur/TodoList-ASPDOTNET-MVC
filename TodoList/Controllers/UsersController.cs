using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers;

public class UsersController : Controller
{
    private readonly DatabaseContext _database;

    public UsersController(DatabaseContext database)
    {
        _database = database;
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        
            _database.Users.Add(user);
            _database.SaveChanges();
            return RedirectToAction("ListUsers");
    }
    
    public IActionResult ListUsers()
    {
        return View(_database.Users.ToList());
    }

    public IActionResult CreateUser()
    {
        return View();
    }

}