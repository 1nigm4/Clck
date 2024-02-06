using Clck.Domain.Models;

namespace Clck.DAL.Repositories
{
    public interface ILinkRepository
    {
        Task<bool> CreateAsync(Link link);
        Task<IEnumerable<Link>> ReadAsync();
        Task<Link?> ReadAsync(string id);
        Task<Link?> ReadByUrlAsync(string url);
        Task<bool> DeleteAsync(Link link);
    }
}
