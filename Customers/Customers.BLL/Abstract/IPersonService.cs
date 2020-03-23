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
        Task<Person> Add(Person person);
        Task<Person> Update(Person person);
        Task<bool> Delete(int id);
    }
}
