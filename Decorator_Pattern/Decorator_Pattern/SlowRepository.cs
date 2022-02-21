using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public class SlowRepository : IRepository
    {
        private readonly List<Person> _people = new();

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            await Task.Delay(1000);
            return _people.Single(p => p.Id == id);
        }

        public Task SavePersonAsync(Person person)
        {
            _people.Add(person);
            return Task.CompletedTask;
        }
    }
}
