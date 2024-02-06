using Clck.DAL.Repositories;
using Clck.Domain.Models;
using System.Text;

namespace Clck.Web.Managers
{
    public class LinkManager
    {
        private readonly ILinkRepository _repository;
        private readonly Random _random;

        public LinkManager(
            ILinkRepository repository,
            Random random)
        {
            _repository = repository;
            _random = random;
        }

        public async Task<Link> CreateAsync(string url)
        {
            Link link = new Link()
            {
                Id = await GenerateUniqueIdAsync(),
                Url = url
            };
            
            await _repository.CreateAsync(link);
            return link;
        }

        public async Task<IEnumerable<Link>> GetAsync()
        {
            return await _repository.ReadAsync();
        }

        public Task<Link?> GetAsync(string id)
        {
            return _repository.ReadAsync(id);
        }
        
        public Task<Link?> GetByUrlAsync(string url)
        {
            return _repository.ReadByUrlAsync(url);
        }

        public Task<bool> DeleteAsync(Link link)
        {
            return _repository.DeleteAsync(link);
        }

        private async Task<string> GenerateUniqueIdAsync()
        {
            string id = string.Empty;
            bool isExist = true;
            while (isExist)
            {
                id = GenerateId();
                isExist = await _repository.ReadAsync(id) != null;
            }

            return id;
        }

        private string GenerateId()
        {
            int length = _random.Next(4, 6);
            StringBuilder id = new StringBuilder();
            for (int val, i = 0; i < length; i++)
            {
                val = _random.Next(0, 26);
                id.Append(Convert.ToChar(val + 65));
            }

            return id.ToString();
        }
    }
}
