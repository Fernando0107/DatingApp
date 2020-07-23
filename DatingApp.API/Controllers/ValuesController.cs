using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;


// API Controllers
// Contain End Points (Routes)
namespace DatingApp.API.Controllers
{
    // api/values -> api[controller] is just a placeholder
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // We use _ so we don't need to put this.
        private readonly DataContext _context;
        //We use this constructor to use the dependency injection.
        public ValuesController(DataContext context)
        {
            // this.context
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            // Got to the DB at retieve the values into a list
            var values = await _context.Values.ToListAsync();

            return Ok(values);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            // FirstOrDefault help us to get the value of the parmeter we are passing, and if it doesn't exist, returns a "no" not an exception.
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
