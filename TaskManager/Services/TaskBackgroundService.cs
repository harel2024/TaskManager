using Microsoft.EntityFrameworkCore;
using TaskManager.Controllers;
using TaskManager.Data;
using TaskManager.Models;


namespace TaskManager.Services
{
    //public class TaskBackgroundService : BackgroundService
    //{
    //    private static readonly TaskManagerDbContex _context; // Holds the DB context

    //    public TaskBackgroundService(TaskManagerDbContex context)
    //    {
    //        _context = context;
    //    }
    //    public static async Task IsTaskLate()
    //    {
    //        Task.Run(async () =>
    //        while (true)
    //        {
    //            if (_context.Tasks.Count() > 0)
    //            {
    //                //List<Task> tasks = _context.Tasks.Where(t => t.Status != "completed");
    //                List<TaskItem> tasks = _context.Tasks.Where(t => t.Status != true);
    //                foreach (Task task in tasks)
    //                {
    //                    if (task.DueDate < DateTime.Now)
    //                    {
    //                        task.Status = false;
    //                        _context.SaveChangs);
    //                    }
    //                }
    //            }
    //            await Task.Delay(60000);
    //        }
    //    }

    //    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
