using Customers.BLL.Abstract;
using Customers.DAL;
using Customers.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly test_dbContext db;

        public PersonService(test_dbContext db)
        {
            this.db = db;
        }

        //public async Task<Country> Add(Country country)
        //{
        //    var res = await db.Country.AddAsync(country);

        //    await db.SaveChangesAsync();
        //    return res.Entity;
        //}

        //public async Task<Country> Update(Country country)
        //{
        //    var res = db.Country.Update(country);

        //    await db.SaveChangesAsync();

        //    return res.Entity;
        //}

        //public async Task<bool> Delete(string code)
        //{
        //    var model = await db.Country.FirstOrDefaultAsync(x => x.Code == code);

        //    db.Remove(model);

        //    await db.SaveChangesAsync();

        //    return true;
        //}

        public async Task<Person> Get(int id)
        {
            return await db.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Person> Get()
        {
            return db.Person.AsEnumerable();
        }
    }

}
