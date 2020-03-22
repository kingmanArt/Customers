using Customers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customers.BLL.Abstract
{
    public interface IPersonService
    {
        Task<Person> Get(int code);
        IEnumerable<Person> Get();
        //Task<Country> Add(Country country);
        //Task<Country> Update(Country country);
        //Task<bool> Delete(string code);
    }
}
