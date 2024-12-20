using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBook.Models;
using TaskBook.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskComment>>> GetTaskComments()
        {
            var comments = await _context.TaskComment
                .Include(c => c.Task)  // Включаем информацию о задаче
                .Include(c => c.User)   // Включаем информацию о пользователе
                .ToListAsync();

            return Ok(comments.Select(c => new
            {
                c.Id,
                c.CommentText,
                c.Date,
                TaskTitle = c.Task.Title,  // Возвращаем название задачи
                UserFullName = $"{c.User.Forename} {c.User.Surname} {c.User.Lastname}" // Формируем ФИО пользователя
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskComment>> GetTaskComment(int id)
        {
            var comment = await _context.TaskComment
                .Include(c => c.Task)  // Включаем информацию о задаче
                .Include(c => c.User)   // Включаем информацию о пользователе
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                comment.Id,
                comment.CommentText,
                comment.Date,
                TaskTitle = comment.Task.Title,  // Возвращаем название задачи
                UserFullName = $"{comment.User.Forename} {comment.User.Surname} {comment.User.Lastname}" // Формируем ФИО пользователя
            });
        }

        [HttpPost]
        public async Task<ActionResult<TaskComment>> CreateTaskComment([FromBody] TaskComment comment)
        {
            var task = await _context.Task.FindAsync(comment.TaskId);
            var user = await _context.User.FindAsync(comment.UserId);

            if (task == null || user == null)
            {
                return BadRequest("Invalid Task or User ID.");
            }

            comment.Task = task;
            comment.User = user;

            _context.TaskComment.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskComment), new { id = comment.Id }, new
            {
                comment.Id,
                comment.CommentText,
                comment.Date,
                TaskTitle = comment.Task.Title,
                UserFullName = $"{comment.User.Forename} {comment.User.Surname} {comment.User.Lastname}"
            });
        }

        // PUT: api/TaskComments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskComment(int id, [FromBody] TaskComment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                comment.Id,
                comment.CommentText,
                comment.Date,
                TaskTitle = comment.Task.Title,  // Возвращаем название задачи
                UserFullName = $"{comment.User.Forename} {comment.User.Surname} {comment.User.Lastname}" // Формируем ФИО пользователя
            });
        }

        // DELETE: api/TaskComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskComment(int id)
        {
            var comment = await _context.TaskComment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.TaskComment.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}