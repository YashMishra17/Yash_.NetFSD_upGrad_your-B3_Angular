using Contact_Management_API.Models;
using Contact_Management_API.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace Contact_Management_API.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            string cacheKey = "contact_list";

            if (!_cache.TryGetValue(cacheKey, out List<Contact> contacts))
            {
                Console.WriteLine("Fetching from DB...");
                contacts = await _repo.GetAllAsync();

                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                _cache.Set(cacheKey, contacts, options);
            }
            else
            {
                Console.WriteLine("Fetching from CACHE...");
            }

            return contacts;
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            string cacheKey = $"contact_{id}";

            if (!_cache.TryGetValue(cacheKey, out Contact contact))
            {
                Console.WriteLine("Fetching from DB...");
                contact = await _repo.GetByIdAsync(id);

                if (contact != null)
                {
                    var options = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                    _cache.Set(cacheKey, contact, options);
                }
            }
            else
            {
                Console.WriteLine("Fetching from CACHE...");
            }

            return contact;
        }
    }
}
