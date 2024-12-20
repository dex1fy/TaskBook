using Microsoft.EntityFrameworkCore;
using TaskBook.Models;

namespace TaskBook.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<TaskBook.Models.Role> Role { get; set; }
    public DbSet<TaskBook.Models.User> User { get; set; }
    public DbSet<TaskBook.Models.TaskStatus> TaskStatus { get; set; }
    public DbSet<TaskBook.Models.TaskPriority> TaskPrioritiy { get; set; }
    public DbSet<TaskBook.Models.TaskCategory> TaskCategory { get; set; }
    public DbSet<TaskBook.Models.TaskLabel> TaskLabel { get; set; }
    public DbSet<TaskBook.Models.Task> Task { get; set; }
    public DbSet<TaskBook.Models.TaskComment> TaskComment { get; set; }
    public DbSet<TaskBook.Models.TaskAttachment> TaskAttachment { get; set; }
    public DbSet<TaskBook.Models.TaskAssignee> TaskAssignee { get; set; }
    public DbSet<TaskBook.Models.TaskRating> TaskRating { get; set; }
    public DbSet<TaskBook.Models.TaskCategoryAssignment> TaskCategoryAssignment { get; set; }
    public DbSet<TaskBook.Models.TaskLabelAssignment> TaskLabelAssignment { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskAssignee>()
            .HasKey(ta => new { ta.TaskId, ta.UserId });

        modelBuilder.Entity<TaskCategoryAssignment>()
            .HasKey(tca => new { tca.TaskId, tca.CategoryId });

        modelBuilder.Entity<TaskLabelAssignment>()
            .HasKey(tla => new { tla.TaskId, tla.LabelId });

        modelBuilder.Entity<TaskRating>()
            .HasKey(tr => new { tr.TaskId, tr.UserId });

      
    }
}

   
