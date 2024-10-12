using Microsoft.AspNetCore.Mvc;
using ToDoBack.Models;

namespace ToDoBack.Services
{
    public interface ITodoService
    {
        Task<ActionResult<List<Todo>>> GetTodo();

        Task<ActionResult<Todo>> GetTodobyId(int id);
        Task<ActionResult<Todo>> CreateTodo(Todo td);
        Task<ActionResult<Todo>> UpdateTodo(int id, Todo td);
        Task<ActionResult<Todo>> DeleteTodo(int id);
    }
}
