using Domain.DTOs;

namespace Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public static Contact Create(ContactDTO contact)
        {
            
            return null;
        }
    }
}