using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class Department
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; }
}