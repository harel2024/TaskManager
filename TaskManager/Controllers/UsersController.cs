using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;
using TaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly TaskManagerDbContex _context; // Holds the DB context
        private readonly ILogger<UsersController> _logger; // Holds logger to log stuff



        public UsersController(TaskManagerDbContex context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }
        //להביא את כל הקיימות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUser(int id)
        {
            //return await _context.Tasks.ToListAsync()
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user == null)
            {
                return NotFound();
            }
          
            await _context.Users.ToListAsync();
            return Ok(user);

        }
        [HttpPost("creat")]
        public async Task<ActionResult<IEnumerable<Users>>> CreatTask(Users user)
        {

            if (user == null)
            {
                return BadRequest("Task cannot be null");
            }

            // Add the task to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Return the list of tasks including the newly created one
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> UpdateTask(int id, Users user)
        {

            var existUser = _context.Users.FirstOrDefault(user => user.Id == id);
            if (existUser == null)
            {
                return NotFound();
            }
            existUser.Name = user.Name;
            existUser.Password = user.Password;
            existUser.Email = user.Email;
            existUser.Items = user.Items;
         
            await _context.SaveChangesAsync();
            return Ok(existUser);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {

            var existUser = _context.Users.FirstOrDefault(user => user.Id == id);
            if (existUser == null)
            {
                return NotFound();
            }
            _context.Users.Remove(existUser);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}


