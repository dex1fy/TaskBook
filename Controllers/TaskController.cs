using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TaskBook.Models;
using TaskBook.Data;

namespace TaskBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {
            return await _context.Task.Include(t => t.Status)
                                       .Include(t => t.Priority)
                                       .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetTask(int id)
        {
            var task = await _context.Task.Include(t => t.Status)
                                           .Include(t => t.Priority)
                                           .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpPost]
        public async Task<ActionResult<TaskComment>> CreateTaskComment([FromBody] TaskComment comment)
        {
            var task = await _context.Task.FindAsync(comment.TaskId);
            if (task == null)
            {
                return BadRequest("Task not found.");
            }
           
            var user = await _context.User.FindAsync(comment.UserId);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

      
            comment.Task = task;
            comment.User = user;
         
            _context.TaskComment.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(TaskComment), new { id = comment.Id }, new
            {
                comment.Id,
                comment.CommentText,
                comment.Date,
                TaskTitle = comment.Task.Title,
                UserFullName = $"{comment.User.Forename} {comment.User.Surname} {comment.User.Lastname}"
            });
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Task.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}