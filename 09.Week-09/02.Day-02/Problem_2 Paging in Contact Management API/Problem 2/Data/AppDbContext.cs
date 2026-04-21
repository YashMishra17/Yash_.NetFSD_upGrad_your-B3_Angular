using Contact_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
