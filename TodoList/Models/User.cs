using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models;

public class User
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Todo> Todos { get; set; }
    [ForeignKey("DepartmentId")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}