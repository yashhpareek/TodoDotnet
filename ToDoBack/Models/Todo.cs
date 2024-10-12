using System.ComponentModel.DataAnnotations;

namespace ToDoBack.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }

        public string Category { get; set; }
    }
}
