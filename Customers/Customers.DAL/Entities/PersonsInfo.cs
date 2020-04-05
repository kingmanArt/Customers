using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.DAL.Entities
{
   public class PersonsInfo
    {
        public PersonsInfo()
        {
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Cpny { get; set; }
        public string Street { get; set; }
        public string CountryCode { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public sbyte GenderId { get; set; }
        public int GreetingId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime FirstContact { get; set; }
        public string Notes { get; set; }
        public int PersonId { get; set; }

        // COUNTRY 
        public string ConTxt1 { get; set; }
        public string ConTxt2 { get; set; }
        public string ConTxt3 { get; set; }
        public string ConTxt4 { get; set; }

        //GREETING
        public string GrTxt1 { get; set; }
        public string GrTxt2 { get; set; }
        public string GrTxt3 { get; set; }
        public string GrTxt4 { get; set; }

        public string Txt { get; set; }
        public string GetCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Greeting Greeting { get; set; }
        public ICollection<PersonContact> PersonContacts { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
