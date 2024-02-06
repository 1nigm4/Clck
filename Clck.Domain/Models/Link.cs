#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Clck.Domain.Models
{
    public class Link
    {
        public string Id { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
