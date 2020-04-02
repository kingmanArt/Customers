using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Customers.DAL.Entities;

namespace Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly test_dbContext _context;

        public GreetingsController(test_dbContext context)
        {
            _context = context;
        }

        // GET: api/Greetings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Greeting>>> GetGreeting()
        {
            return await _context.Greeting.ToListAsync();
        }

       

        private bool GreetingExists(int id)
        {
            return _context.Greeting.Any(e => e.Id == id);
        }
    }
}
