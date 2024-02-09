using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models;

public class Todo
{
    [Key] public int Id { get; set; }
    public required string Title { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public required User User { get; set; }
}