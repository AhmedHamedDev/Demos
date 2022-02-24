using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public interface IDataAccess
    {
        public List<Person> GetPeople();

        public Person InsertPerson(string FirstName, String LastName);
    }
}
