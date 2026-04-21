using Contact_Management_API.Models;

namespace Contact_Management_API.Services
{
    public interface IContactService
    {
        Task<PagedResult<Contact>> GetContactsAsync(int pageNumber, int pageSize);

    }
}
