using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.DAL.Entities
{
   public class PersonContactInfo
    {
        public PersonContactInfo(Person person)
        {
            foreach (var item in person.PersonContact)
            {
                Txt = item.Txt;
                PersonId = item.PersonId;
            }
        }
        public string Txt { get; set; }
        public int PersonId { get; set; }

    }
}
