using Microsoft.EntityFrameworkCore;

namespace ToDoBack.Models
{
    public class TodoDBContext :DbContext
    {
        public TodoDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
