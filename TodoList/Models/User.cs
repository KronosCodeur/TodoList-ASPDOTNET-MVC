using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class User
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Todo> Todos { get; set; }
}