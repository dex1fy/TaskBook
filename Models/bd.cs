using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskBook.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Forename { get; set; }
    public string Lastname { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int? RoleId { get; set; }
    public Role Role { get; set; }
}

public class TaskStatus
{
    public int Id { get; set; }
    public string StatusName { get; set; }
}

public class TaskPriority
{
    public int Id { get; set; }
    public string PriorityName { get; set; }
}

public class TaskCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class TaskLabel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public int? StatusId { get; set; }
    public TaskStatus Status { get; set; }
    public int? PriorityId { get; set; }
    public TaskPriority Priority { get; set; }
    public ICollection<TaskCategoryAssignment> TaskCategoryAssignments { get; set; }
    public ICollection<TaskLabelAssignment> TaskLabelAssignments { get; set; }
}

public class TaskCategoryAssignment
{
    public int TaskId { get; set; }
    public Task Task { get; set; }
    public int CategoryId { get; set; }
    public TaskCategory Category { get; set; }
}

public class TaskLabelAssignment
{
    public int TaskId { get; set; }
    public Task Task { get; set; }
    public int LabelId { get; set; }
    public TaskLabel Label { get; set; }
}

public class TaskComment
{
    public int Id { get; set; }
    public string CommentText { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int TaskId { get; set; }
    public Task Task { get; set; }
}

public class TaskAttachment
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public int TaskId { get; set; }
    public Task Task { get; set; }
}

public class TaskAssignee
{
    public int TaskId { get; set; }
    public Task Task { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}

public class TaskRating
{
    public int Rating { get; set; }
    public int TaskId { get; set; }
    public Task Task { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}