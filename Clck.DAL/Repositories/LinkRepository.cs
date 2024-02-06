using Clck.Domain;
using Clck.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Clck.DAL.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly ApplicationDbContext _context;

        public LinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Link link)
        {
            var entry = await _context.Set<Link>()
                .AddAsync(link);

            await _context.SaveChangesAsync();
            return entry.State == Microsoft.EntityFrameworkCore.EntityState.Unchanged;
        }

        public async Task<bool> DeleteAsync(Link link)
        {
            var entry = _context.Set<Link>()
                .Remove(link);

            await _context.SaveChangesAsync();
            return entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public async Task<IEnumerable<Link>> ReadAsync()
        {
            return await _context.Set<Link>()
                .ToArrayAsync();
        }

        public async Task<Link?> ReadAsync(string id)
        {
            return await _context.Set<Link>()
                .FindAsync(id);
        }

        public async Task<Link?> ReadByUrlAsync(string url)
        {
            return await _context.Set<Link>()
                .FirstOrDefaultAsync(link => link.Url == url);
        }
    }
}
