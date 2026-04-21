using Contact_Management_API.Data;
using Contact_Management_API.Models;
using Contact_Management_API.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace Contact_Management_API.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public async Task<PagedResult<Contact>> GetContactsAsync(int pageNumber, int pageSize)
        {
            // basic validation
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 5 : pageSize;

            return await _repo.GetPagedAsync(pageNumber, pageSize);
        }
    }
}
