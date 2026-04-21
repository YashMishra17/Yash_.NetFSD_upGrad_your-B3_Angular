using Contact_Management_API.Data;
using Contact_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management_API.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Contact>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Contacts.AsQueryable();

            int totalRecords = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Contact>
            {
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data
            };
        }
    }    
}


