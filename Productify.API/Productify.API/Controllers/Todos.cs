using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productify.DAL.Context;
using Productify.DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Productify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todos : ControllerBase
    {
        private readonly IDbContextFactory<ProductifyDataContext> _productifyDataContext;

        public Todos(IDbContextFactory<ProductifyDataContext> productifyDataContext)
        {
            _productifyDataContext = productifyDataContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Todo>> Get()
        {
            var db = await _productifyDataContext.CreateDbContextAsync();
            var todos = db.Todos.ToList();
            return todos;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<Todo> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize]
        public async void Post([FromBody] Todo todo)
        {
            try
            {
                var db = await _productifyDataContext.CreateDbContextAsync();
                db.Todos.Add(todo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}
