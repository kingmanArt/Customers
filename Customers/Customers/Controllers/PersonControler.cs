using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Customers.DAL.Entities;
using Customers.BLL.Abstract;


namespace Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonControler : ControllerBase
    {
        private readonly IPersonService person;

        public PersonControler(IPersonService person)
        {
            this.person = person; 
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<Person> Get(int id)
        {
            return await person.Get(id);
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return person.Get();
        }
    }
}
