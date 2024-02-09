using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers;

public class DepartmentController : Controller
{
    private readonly DatabaseContext _database;

    public DepartmentController(DatabaseContext database)
    {
        _database = database;
    }
    
    [HttpPost]
    public IActionResult CreateDepartment(Department department)
    {
        
        _database.Departments.Add(department);
        _database.SaveChanges();
        ViewBag.Departements = _database.Departments.ToList();
        return RedirectToAction("ListDepartments");
    }
    
    public IActionResult ListDepartments()
    {
        return View(_database.Departments.ToList());
    }
    
    public IActionResult CreateDepartment()
    {
        
        return View();
    }
}