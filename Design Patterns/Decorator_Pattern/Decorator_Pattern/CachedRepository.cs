using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public class CachedRepository : IRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IRepository _repository;

        public CachedRepository(IMemoryCache memoryCache, IRepository repository)
        {
            _memoryCache = memoryCache;
            _repository = repository;
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            if (!_memoryCache.TryGetValue(id, out Person value))
            {
                value = await _repository.GetPersonByIdAsync(id);
                _memoryCache.Set(id, value);
            }

            return value;
        }

        public Task SavePersonAsync(Person person)
        {
            return _repository.SavePersonAsync(person);
        }
    }
}
