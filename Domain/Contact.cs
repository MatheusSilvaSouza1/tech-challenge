using Domain.DTOs;
using Domain.Validations;
using FluentValidation.Results;

namespace Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DDDId { get; set; }
        public DDD DDD { get; set; }
        public ValidationResult ValidationResult { get; set; } = new();

        private Contact()
        {
        }

        public static Contact Create(ContactDTO contact)
        {
            var domainContact = new Contact()
            {
                Email = contact.Email,
                Name = contact.Name,
                Phone = contact.Phone[2..],
                DDDId = Convert.ToInt32(contact.Phone[..2])
            };

            domainContact.ValidationResult = new CreateContactValidation().Validate(domainContact);

            return domainContact;
        }

        public static Contact Update(ContactUpdateDTO contact)
        {
            var domainContact = new Contact()
            {
                Id = contact.Id,
                Email = contact.Email,
                Name = contact.Name,
                Phone = contact.Phone[2..],
                DDDId = Convert.ToInt32(contact.Phone[..2])
            };

            domainContact.ValidationResult = new CreateContactValidation().Validate(domainContact);

            return domainContact;
        }
    }
}