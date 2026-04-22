using Contact_Management_API.Models;

namespace Contact_Management_API.Services
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        void UpdateContact(int id, Contact updatedContact);
        void DeleteContact(int id);
        IEnumerable<Contact> GetAllContacts();

    }
}
