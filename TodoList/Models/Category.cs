using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class Category
{
    [Key] public int Id {
        get;
        set;
    }

    public string Title { get; set; } = string.Empty;
    public ICollection<Todo> Todos { get; set; }
}