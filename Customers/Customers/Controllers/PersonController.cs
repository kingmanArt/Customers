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
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService; 
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<Person> Get(int id)
        {
            return await personService.Get(id);
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return personService.Get();
        }

        [HttpPost]
        public async Task<Person> Add([FromBody] Person person)
        {
            return await personService.Add(person);
        }

        [HttpPut]
        public async Task<Person> Update([FromBody] Person person)
        {
            return await personService.Update(person);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await personService.Delete(id);
        }
    }
}
