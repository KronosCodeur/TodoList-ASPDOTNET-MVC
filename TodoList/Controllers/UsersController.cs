using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Departements = _database.Departments.ToList();
            return RedirectToAction("ListUsers");
    }
    
    public IActionResult ListUsers()
    {
        return View(_database.Users.Include(u=>u.Department).ToList());
    }

    public IActionResult CreateUser()
    {
        ViewData["DepartmentId"] = new SelectList(_database.Departments, "Id", "Name");
        return View();
    }

}