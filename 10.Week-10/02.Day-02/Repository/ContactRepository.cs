using Contact_Management_API.Models;
using System.Xml.Linq;

namespace ContactManagement.API.Repository;

public class ContactRepository : IContactRepository
{
    private readonly List<Contact> _contacts = new();

    public List<Contact> GetAll()
    {
        return _contacts;
    }

    public Contact? GetById(int id)
    {
        return _contacts.FirstOrDefault(c => c.Id == id);
    }

    public void Add(Contact contact)
    {
        contact.Id = _contacts.Count == 0 ? 1 : _contacts.Max(c => c.Id) + 1;
        _contacts.Add(contact);
    }

    public void Update(int id, Contact contact)
    {
        var existing = GetById(id);
        if (existing == null)
            throw new Exception("Contact not found");

        existing.Name = contact.Name;
        existing.Email = contact.Email;
        existing.Phone = contact.Phone;
    }

    public void Delete(int id)
    {
        var contact = GetById(id);
        if (contact == null)
            throw new Exception("Contact not found");

        _contacts.Remove(contact);
    }
}
