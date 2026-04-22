using Contact_Management_API.Models;

namespace Contact_Management_API.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();

        public void AddContact(Contact contact)
        {
            ValidateContact(contact);

            contact.Id = GenerateId();
            _contacts.Add(contact);
        }

        public void UpdateContact(int id, Contact updatedContact)
        {
            var existing = GetContactById(id);

            ValidateContact(updatedContact);

            existing.Name = updatedContact.Name;
            existing.Email = updatedContact.Email;
            existing.Phone = updatedContact.Phone;
        }

        public void DeleteContact(int id)
        {
            var contact = GetContactById(id);
            _contacts.Remove(contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts;
        }

        // Helper Methods (reduce complexity)

        private Contact GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                throw new ArgumentException("Contact not found.");
            }

            return contact;
        }

        private static void ValidateContact(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name is required.");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new ArgumentException("Email is required.");

            if (string.IsNullOrWhiteSpace(contact.Phone))
                throw new ArgumentException("Phone is required.");
        }

        private int GenerateId()
        {
            return _contacts.Count == 0 ? 1 : _contacts.Max(c => c.Id) + 1;
        }
    }
}
