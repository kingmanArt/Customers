using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Customers.DAL.Entities;
using System.Web.Http.Description;

namespace Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly test_dbContext _context;

        public PersonController(test_dbContext context)
        {
            _context = context;
        }

        // GET: api/Person
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        //{

        //    return await _context.Person
        //                               .Include(per => per.PersonContact)
        //                               .To();
           
        //}
        public IEnumerable<PersonsInfo> GetPerson()
        {
            return _context.Person.Include(b => b.Greeting)
                                  .Include(b => b.PersonContact)
                                  .Include(b => b.CountryCodeNavigation)
                                    .Select(b =>
       new PersonsInfo()
       {
           Id = b.Id,
           Fname = b.Fname,
           Lname = b.Lname,
           Cpny = b.Cpny,
           Street = b.Street,
           Zip = b.Zip,
           City = b.City,
           DateOfBirth = b.DateOfBirth,
           FirstContact = b.FirstContact,
           Title = b.Title,

           GrTxt1 = b.Greeting.Txt1,
           GrTxt2 = b.Greeting.Txt2,
           GrTxt3 = b.Greeting.Txt3,
           GrTxt4 = b.Greeting.Txt4,

           ConTxt1 = b.CountryCodeNavigation.Txt1,
           ConTxt2 = b.CountryCodeNavigation.Txt2,
           ConTxt3 = b.CountryCodeNavigation.Txt3,
           ConTxt4 = b.CountryCodeNavigation.Txt4,

           


       }).AsEnumerable();

            //_context.Person/*.Include(x => x.PersonContact)*/.AsEnumerable();
        }
       // GET: api/Person/5
       [HttpGet("{id}")]
        [ResponseType(typeof(PersonContact))]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            //var person = _context.Person
            //                            .Include(per => per.Greeting)
            //                            .Include(per => per.PersonContact)
            //                            .Include(per => per.CountryCodeNavigation)
            //                            .Where(per => per.Id == id)
            //                            .FirstOrDefault();

            //if (person == null)
            //{
            //    return NotFound();
            //}

            //return person;

            var person = await _context.Person.Include(b => b.Greeting).Select(b =>
        new PersonsInfo()
        {
            PersonId = b.Id,
            Fname = b.Fname,
            
           
            
        }).SingleOrDefaultAsync(b => b.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        
    }

        // PUT: api/Person/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Person
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return person;
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
