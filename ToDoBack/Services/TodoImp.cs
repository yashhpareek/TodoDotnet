using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoBack.Models;

namespace ToDoBack.Services
{
    public class TodoImp : ITodoService
    {
        private readonly TodoDBContext _context;

        public TodoImp(TodoDBContext context)
        {
            _context = context;
        }

        // Get all todos
        public async Task<ActionResult<List<Todo>>> GetTodo()
        {
            var data = await _context.Todos.ToListAsync();
            return data;
        }

        // Get todo by ID
        public async Task<ActionResult<Todo>> GetTodobyId(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return new NotFoundResult();
            }
            return todo;
        }

        // Create a new todo
        public async Task<ActionResult<Todo>> CreateTodo(Todo td)
        {
            await _context.Todos.AddAsync(td);
            await _context.SaveChangesAsync();
            return new OkObjectResult(td);
        }

        // Update an existing todo by ID
        public async Task<ActionResult<Todo>> UpdateTodo(int id, Todo td)
        {
            if (id != td.Id)
            {
                return new BadRequestResult();
            }

            _context.Entry(td).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return new NotFoundResult();
                }
                throw;
            }

            return new OkObjectResult(td);
        }

        // Delete a todo by ID
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            var td = await _context.Todos.FindAsync(id);
            if (td == null)
            {
                return new NotFoundResult();
            }

            _context.Todos.Remove(td);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        // Helper method to check if the todo exists
        private bool TodoExists(int id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}
