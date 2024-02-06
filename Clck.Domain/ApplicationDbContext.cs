using Clck.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Clck.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Link> Links { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
