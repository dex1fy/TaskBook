using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBook.Models;
using TaskBook.Data;


namespace TaskBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAttachmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskAttachmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskAttachments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskAttachment>>> GetTaskAttachments()
        {
            var attachments = await _context.TaskAttachment
                .Include(t => t.Task)  
                .ToListAsync();

            return Ok(attachments.Select(a => new
            {
                a.Id,
                a.FileName,
                a.FilePath,
                TaskTitle = a.Task.Title  
            }));
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskAttachment>> GetTaskAttachment(int id)
        {
            var attachment = await _context.TaskAttachment
                .Include(t => t.Task)  
                .FirstOrDefaultAsync(a => a.Id == id);

            if (attachment == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                attachment.Id,
                attachment.FileName,
                attachment.FilePath,
                TaskTitle = attachment.Task.Title  
            });
        }

        
        [HttpPost]
        public async Task<ActionResult<TaskAttachment>> CreateTaskAttachment([FromBody] TaskAttachment attachment)
        {
            _context.TaskAttachment.Add(attachment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskAttachment), new { id = attachment.Id }, new
            {
                attachment.Id,
                attachment.FileName,
                attachment.FilePath,
                TaskTitle = attachment.Task.Title
            });
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAttachment(int id, [FromBody] TaskAttachment attachment)
        {
            if (id != attachment.Id)
            {
                return BadRequest();
            }

            _context.Entry(attachment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                attachment.Id,
                attachment.FileName,
                attachment.FilePath,
                TaskTitle = attachment.Task.Title
            });
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAttachment(int id)
        {
            var attachment = await _context.TaskAttachment.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }

            _context.TaskAttachment.Remove(attachment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}