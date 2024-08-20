using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime? DueDate { get; set; }= DateTime.Now;

        public bool Priority { get; set; }

        public Users? User { get; set; }
     
        
        


    }
}
