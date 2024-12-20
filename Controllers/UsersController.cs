using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TaskBook.Models;
using TaskBook.Data;


//namespace TheTaskBook.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly ApplicationDbContext _dbcontext;

//        public UsersController(ApplicationDbContext dbcontext) =>
//        _dbcontext = dbcontext;


//        //получение всех пользоватеолй
//        [HttpGet]
//        public async Task<List<User>> Get()
//        {
//            return await _dbcontext.User.ToListAsync();
//        }

//        //получение конкретноо пользователя

//        [HttpGet("{id}")]
//        public async Task<User?> GetById(int id)
//        {
//            return await _dbcontext.User.FirstOrDefaultAsync(x => x.Id == id);
//        }

//        [HttpPost]
//        public async Task<ActionResult> Create([FromBody] User users)
//        {
//            if (string.IsNullOrWhiteSpace(users.Forename) ||
//                     string.IsNullOrWhiteSpace(users.Lastname) ||
//                     string.IsNullOrWhiteSpace(users.Surname) ||
//                     string.IsNullOrWhiteSpace(users.Email) ||
//                     string.IsNullOrWhiteSpace(users.Password))
//            {
//                return BadRequest("Invalid Request");
//            }


//            await _dbcontext.User.AddAsync(users);
//            await _dbcontext.SaveChangesAsync();
//            return CreatedAtAction(nameof(GetById), new { id = users.Id }, users);
//        }

//[HttpPut]
//public async Task<ActionResult> Update([FromBody] User users)
//{
//    if (string.IsNullOrWhiteSpace(users.Forename) ||
//            string.IsNullOrWhiteSpace(users.Lastname) ||
//            string.IsNullOrWhiteSpace(users.Surname) ||
//            string.IsNullOrWhiteSpace(users.Email) ||
//            string.IsNullOrWhiteSpace(users.Password))
//    {
//        return BadRequest("Invalid Request");
//    }
//    _dbcontext.User.Update(users);
//    await _dbcontext.SaveChangesAsync();

//    return Ok();

//}

//        [HttpDelete("{id}")]

//        public async Task<ActionResult> Delete(int id)
//        {
//            var users = await GetById(id);
//            if (users is null)
//                return NotFound();

//            _dbcontext.User.Remove(users);
//            await _dbcontext.SaveChangesAsync();
//            return Ok();

//        }
//    }
//}



// UsersController.cs



namespace TaskBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.User
                .Include(u => u.Role)  // Включаем информацию о роли
                .ToListAsync();

            return Ok(users.Select(u => new
            {
                u.Id,
                u.Forename,
                u.Lastname,
                u.Surname,
                u.Email,
                RoleName = u.Role.Name  // Возвращаем название роли
            }));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User
                .Include(u => u.Role)  
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                user.Id,
                user.Forename,
                user.Lastname,
                user.Surname,
                user.Email,
                RoleName = user.Role.Name  // Возвращаем название роли
            });
        }

        //// POST: api/Users
        //[HttpPost]
        //public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        //{
        //    _context.User.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new
        //    {
        //        user.Id,
        //        user.Forename,
        //        user.Lastname,
        //        user.Surname,
        //        user.Email,
        //        RoleName = user.Role.Name
        //    });
        //}



        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
    
            var role = await _context.Role.FindAsync(user.RoleId);  

            if (role == null)
            {
                return BadRequest("Role not found.");
            }

            
            user.Role = role;

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new
            {
                user.Id,
                user.Forename,
                user.Lastname,
                user.Surname,
                user.Email,
                RoleName = user.Role.Name
            });
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                user.Id,
                user.Forename,
                user.Lastname,
                user.Surname,
                user.Email,
                RoleName = user.Role.Name
            });
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}