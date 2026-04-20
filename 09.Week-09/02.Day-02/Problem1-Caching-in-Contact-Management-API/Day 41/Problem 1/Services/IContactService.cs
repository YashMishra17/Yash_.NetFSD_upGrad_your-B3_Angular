using Contact_Management_API.Models;

namespace Contact_Management_API.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
    }
}
