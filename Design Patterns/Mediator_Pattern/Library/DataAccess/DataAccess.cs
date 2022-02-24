using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private List<Person> People = new();

        public DataAccess()
        {
            People.Add(new Person() { Id = 1, FirstName = "Ahmed", LastName = "Hamed" });
            People.Add(new Person() { Id = 2, FirstName = "Hossam", LastName = "Hassan" });
        }

        public List<Person> GetPeople()
        {
            return People;
        }

        public Person InsertPerson(string FirstName, String LastName)
        {
            Person person = new Person() {FirstName = FirstName, LastName = LastName };
            person.Id = People.Max(x => x.Id) + 1;
            People.Add(person);
            return person;
        }
    }
}
