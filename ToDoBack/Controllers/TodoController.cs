using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoBack.Models;
using ToDoBack.Services;

namespace ToDoBack.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [EnableCors]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService todoService;

        public TodoController(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetTodo()
        {
            var data = await todoService.GetTodo();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodobyId(int id)
        {
            var todo = await todoService.GetTodobyId(id);
            if(todo == null)
            {
                return BadRequest();
            }

            return todo;
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(Todo td)
        {
            await todoService.CreateTodo(td);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> UpdateTodo(int id, Todo td)
        {
            if(id != td.Id)
            {
                return BadRequest();
            }

            await todoService.UpdateTodo(id, td);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            await todoService.DeleteTodo(id);
            return Ok();
        }

    }
}
