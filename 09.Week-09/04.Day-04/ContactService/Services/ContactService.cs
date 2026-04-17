using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repo;

    public ContactService(IContactRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Contact>> GetAll() => await _repo.GetAll();
    public async Task<Contact> GetById(int id) => await _repo.GetById(id);
    public async Task<Contact> Add(Contact contact) => await _repo.Add(contact);
    public async Task<Contact> Update(int id, Contact contact) => await _repo.Update(id, contact);
    public async Task<bool> Delete(int id) => await _repo.Delete(id);
}