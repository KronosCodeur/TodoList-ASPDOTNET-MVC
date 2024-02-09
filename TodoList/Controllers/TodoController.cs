using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers;

public class TodoController : Controller
{
    private readonly DatabaseContext _database;

    public TodoController(DatabaseContext database)
    {
        _database = database;
    }
    
    public IActionResult CreateTodo()
    {
        ViewData["UserId"] = new SelectList(_database.Users, "Id", "Name");
        return View();
    }

    public IActionResult ListTodos()
    {
        return View(_database.Todos.Include(t => t.User).ToList());
    }

    [HttpPost]
    public IActionResult CreateTodo(Todo todo)
    {
            _database.Todos.Add(todo);
            _database.SaveChanges();
        ViewBag.Users = _database.Users.ToList();
            return RedirectToAction("ListTodos");
    }
    
}