using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetTodoItems()
        {
            var todoList = await _context.Todos.ToListAsync();
            return Ok(todoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoItem(int id)
        {
            var todoItem = await _context.Todos.FindAsync(id);

            if (todoItem is null)
                return NotFound();
            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> AddTodoItem(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpPut]
        public async Task<ActionResult<Todo>> UpdateTodoItem(Todo updatedTodo)
        {
            var DbTodo = await _context.Todos.FindAsync(updatedTodo.Id);

            if (DbTodo is null)
                return NotFound();

            DbTodo.Title = updatedTodo.Title;
            DbTodo.TodoOwner = updatedTodo.TodoOwner;
            DbTodo.Description = updatedTodo.Description;
            DbTodo.isCompleted = updatedTodo.isCompleted;

            await _context.SaveChangesAsync();
            return Ok(DbTodo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Todo>>> DeleteTodoItem(int id)
        {
            var deletedTodo = await _context.Todos.FindAsync(id);

            if (deletedTodo is null)
                return NotFound();

            _context.Todos.Remove(deletedTodo);
            await _context.SaveChangesAsync();
            return Ok(await _context.Todos.ToListAsync());
        }
    }
}
