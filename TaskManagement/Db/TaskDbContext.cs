using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.Db;

public class TaskDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Issue> Issues { get; set; }

    public TaskDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Issue>(entry =>
        {
            entry.ToTable("task");
            
                entry.HasOne(t => t.Employee)
                    .WithMany()
                    .HasForeignKey(t => t.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull);
                
                entry.HasOne(t => t.Project)
                    .WithMany()
                    .HasForeignKey(t => t.ProjectId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

        modelBuilder.Entity<Project>(entry => { entry.ToTable("project"); });
        modelBuilder.Entity<Employee>(entry => { entry.ToTable("employee"); });

    }
}