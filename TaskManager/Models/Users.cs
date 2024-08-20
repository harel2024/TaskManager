using System.ComponentModel.DataAnnotations;


namespace TaskManager.Models
{
    public class Users
    {
      
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<TaskItem> Items { get; set; }

        
        public Users()
        {
            Items = new List<TaskItem>();
        }
    
    }
    
}
