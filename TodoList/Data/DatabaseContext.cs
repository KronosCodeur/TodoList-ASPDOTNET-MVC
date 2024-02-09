using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Todo>().HasOne<User>(todo => todo.User).WithMany(user => user.Todos)
            .HasForeignKey(todo => todo.UserId).IsRequired();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }
}