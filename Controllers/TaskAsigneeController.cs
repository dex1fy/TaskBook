using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBook.Models;
using TaskBook.Data;

namespace TaskBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssigneeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskAssigneeController(ApplicationDbContext context)
        {
            _context = context;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskAssignee>>> GetTaskAssignees()
        {
            var taskAssignees = await _context.TaskAssignee.Include(ta => ta.Task)
                                                           .Include(ta => ta.User)
                                                           .Select(ta => new
                                                           {
                                                               TaskName = ta.Task.Title,
                                                               UserFullName = $"{ta.User.Forename} {ta.User.Lastname} {ta.User.Surname}",
                                                               ta.TaskId,
                                                               ta.UserId
                                                           })
                                                           .ToListAsync();

            return Ok(taskAssignees);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskAssignee>> GetTaskAssignee(int id)
        {
            var taskAssignee = await _context.TaskAssignee.Include(ta => ta.Task)
                                                           .Include(ta => ta.User)
                                                           .Where(ta => ta.TaskId == id)
                                                           .Select(ta => new
                                                           {
                                                               TaskName = ta.Task.Title,
                                                               UserFullName = $"{ta.User.Forename} {ta.User.Lastname} {ta.User.Surname}",
                                                               ta.TaskId,
                                                               ta.UserId
                                                           })
                                                           .FirstOrDefaultAsync();

            if (taskAssignee == null)
            {
                return NotFound();
            }

            return Ok(taskAssignee);
        }

        
        [HttpPost]
        public async Task<ActionResult<TaskAssignee>> CreateTaskAssignee(TaskAssignee taskAssignee)
        {
            _context.TaskAssignee.Add(taskAssignee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskAssignee", new { id = taskAssignee.TaskId }, taskAssignee);
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAssignee(int id)
        {
            var taskAssignee = await _context.TaskAssignee.FindAsync(id);
            if (taskAssignee == null)
            {
                return NotFound();
            }

            _context.TaskAssignee.Remove(taskAssignee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}