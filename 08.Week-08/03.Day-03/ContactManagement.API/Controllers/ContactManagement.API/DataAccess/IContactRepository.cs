using WebApplication6.Models;

namespace WebApplication6.DataAccess
{
    public interface IContactRepository
    {
        Task<List<ContactInfo>> GetAllAsync();
        Task<ContactInfo?> GetByIdAsync(int id);
        Task<ContactInfo> CreateAsync(ContactInfo contact);
        Task<bool> UpdateAsync(int id, ContactInfo contact);
        Task<bool> DeleteAsync(int id);
    }
}
