using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers;

public class CategoryController : Controller
{
    private readonly DatabaseContext _database;

    public CategoryController(DatabaseContext database)
    {
        _database = database;
    }
    
    [HttpPost]
    public IActionResult CreateCategory(Category category)
    {
        
        _database.Categories.Add(category);
        _database.SaveChanges();
        ViewBag.Categories = _database.Categories.ToList();
        return RedirectToAction("ListCategories");
    }
    
    public IActionResult ListCategories()
    {
        return View(_database.Categories.ToList());
    }
    
    public IActionResult CreateCategory()
    {
        
        return View();
    }
}