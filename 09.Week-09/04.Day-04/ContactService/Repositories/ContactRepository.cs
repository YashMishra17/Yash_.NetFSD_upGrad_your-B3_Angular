using ContactService.Data;
using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ContactDbContext _context;

    public ContactRepository(ContactDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAll()
        => await _context.Contacts.ToListAsync();

    public async Task<Contact> GetById(int id)
        => await _context.Contacts.FindAsync(id);

    public async Task<Contact> Add(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> Update(int id, Contact contact)
    {
        var existing = await _context.Contacts.FindAsync(id);
        if (existing == null) return null;

        existing.Name = contact.Name;
        existing.Email = contact.Email;
        existing.Phone = contact.Phone;
        existing.CategoryId = contact.CategoryId;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> Delete(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null) return false;

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        return true;
    }
}
