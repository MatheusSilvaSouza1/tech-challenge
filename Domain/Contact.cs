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
                Phone = contact.Phone[2..]
            };

            if (int.TryParse(contact.Phone[..2], out int dddId))
            {
                domainContact.DDDId = dddId;
            }
            else
            {
                domainContact.ValidationResult.Errors.Add(new ValidationFailure("Phone", "Invalid DDD"));
            }

            domainContact.ValidationResult = new CreateContactValidation().Validate(domainContact);

            return domainContact;
        }
    }
}