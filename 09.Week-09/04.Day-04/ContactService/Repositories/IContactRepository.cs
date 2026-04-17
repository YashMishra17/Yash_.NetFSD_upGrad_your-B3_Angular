using ContactService.Models;

namespace ContactService.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAll();
    Task<Contact> GetById(int id);
    Task<Contact> Add(Contact contact);
    Task<Contact> Update(int id, Contact contact);
    Task<bool> Delete(int id);
}