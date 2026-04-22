using Contact_Management_API.Models;
using ContactManagement.API.Repository;

namespace ContactManagement.API.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repo;

    public ContactService(IContactRepository repo)
    {
        _repo = repo;
    }

    public List<Contact> GetAll()
    {
        return _repo.GetAll();
    }

    public Contact GetById(int id)
    {
        var contact = _repo.GetById(id);
        if (contact == null)
            throw new Exception("Contact not found");

        return contact;
    }

    public void Add(Contact contact)
    {
        if (string.IsNullOrWhiteSpace(contact.Name))
            throw new Exception("Name is required");

        _repo.Add(contact);
    }

    public void Update(int id, Contact contact)
    {
        _repo.Update(id, contact);
    }

    public void Delete(int id)
    {
        _repo.Delete(id);
    }
}
