using Contact_Management_API.Models;

namespace Contact_Management_API.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
    }
}
