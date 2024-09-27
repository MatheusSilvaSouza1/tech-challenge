using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class ContactMessage
    {
        public string Name { get; set; } = string.Empty;

        [Phone]
        [MinLength(10)]
        [MaxLength(11)]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}