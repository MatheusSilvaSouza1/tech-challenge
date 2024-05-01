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
                Phone = contact.Phone,
            };

            domainContact.ValidationResult = new CreateContactValidation().Validate(domainContact);

            return domainContact;
        }
    }
}