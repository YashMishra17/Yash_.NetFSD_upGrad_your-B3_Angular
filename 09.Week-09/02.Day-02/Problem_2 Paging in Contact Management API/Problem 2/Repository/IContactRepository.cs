using Contact_Management_API.Models;

namespace Contact_Management_API.Repository
{
    public interface IContactRepository
    {
        Task<PagedResult<Contact>> GetPagedAsync(int pageNumber, int pageSize);

    }
}
