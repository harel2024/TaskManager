using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {

        private readonly TaskManagerDbContex _context; // Holds the DB context
        private readonly ILogger<TaskController> _logger; // Holds logger to log stuff



        public TaskController(TaskManagerDbContex context, ILogger<TaskController> logger)
        {
            _context = context;
            _logger = logger;
        }
        //להביא את כל הקיימות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTask(int id)
        {
            //return await _context.Tasks.ToListAsync()
            var task = _context.Tasks.FirstOrDefault(task => task.Id == id);//צריך להוסיף איקלוד ליוזר
            if (task == null)
            {
                return NotFound();
            }
            await _context.Tasks.ToListAsync();
            return Ok(task);

        }
        [HttpPost("creat")]
        public async Task<ActionResult<IEnumerable<TaskItem>>> CreatTask(TaskItem task)
        {

            if (task == null)
            {
                return BadRequest("Task cannot be null");
            }

            // Add the task to the database
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            // Return the list of tasks including the newly created one
            return Ok(task);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItem>> UpdateTask(int id, TaskItem task)
        {

            var existTask = _context.Tasks.FirstOrDefault(task => task.Id == id);
            if (existTask == null)
            {
                return NotFound();
            }
            existTask.Title = task.Title;
            existTask.Description = task.Description;
            existTask.DueDate = task.DueDate;
            existTask.Status = task.Status;
            existTask.Priority = task.Priority;
            await _context.SaveChangesAsync();
            return Ok(existTask);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskItem>> DeleteTask(int id)
        {

            var exisTask = _context.Tasks.FirstOrDefault(task => task.Id == id);
            if (exisTask == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(exisTask);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
