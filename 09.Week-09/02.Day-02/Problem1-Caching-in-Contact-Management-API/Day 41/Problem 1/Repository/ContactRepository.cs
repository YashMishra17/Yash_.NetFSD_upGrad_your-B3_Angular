using Contact_Management_API.Models;

namespace Contact_Management_API.Repository
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> contacts = new()
    {
        new Contact { Id = 1, Name = "John", Email = "john@mail.com" },
        new Contact { Id = 2, Name = "Alice", Email = "alice@mail.com" }
    };

        public async Task<List<Contact>> GetAllAsync()
        {
            await Task.Delay(2000); // simulate DB delay
            return contacts;
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            await Task.Delay(2000); // simulate DB delay
            return contacts.FirstOrDefault(c => c.Id == id);
        }
    }    
}


