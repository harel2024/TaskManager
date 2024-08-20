using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class TaskManagerDbContex : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Users> Users { get; set; }

        private void Seed()
        {
            if (!Users.Any()&&!Tasks.Any())
            {
                Users user1 = new Users { Name = "הראל", Password = "1234", Email = "Aral@gmail" };
                Users.Add(user1);
                SaveChanges();
                TaskItem task1 = new TaskItem {  Title = "רשימת קניות", Status = true, Description = "wolt", DueDate = DateTime.Now,User = user1 };

                Tasks.Add(task1);
                SaveChanges();
            }
         
        }
        public TaskManagerDbContex(DbContextOptions<TaskManagerDbContex> options)
     : base(options)
        {
            // לוודא שהבסיס נתונים והטבלאות קיימות, אם לא תייצר את כולם ריקות
            Console.WriteLine("Database Exists: " + Database.EnsureCreated());
            Seed();
        }
    }
}