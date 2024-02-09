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
        modelBuilder.Entity<User>().HasOne<Department>(user =>user.Department).WithMany(department => department.Users)
            .HasForeignKey(user => user.DepartmentId).IsRequired();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Department> Departments { get; set; }
}