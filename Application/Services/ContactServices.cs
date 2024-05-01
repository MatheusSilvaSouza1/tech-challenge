using Domain;
using Domain.DTOs;
using Domain.Repositories;

namespace Application.Services
{
    public class ContactServices(IContactRepository contactRepository) : IContactServices
    {
        private readonly IContactRepository _contactRepository = contactRepository;

        public async Task<Contact> CreateContact(ContactDTO contact)
        {
            var domainContact = Contact.Create(contact);

            if (!domainContact.ValidationResult.IsValid)
            {
                return domainContact;
            }

            _contactRepository.Create(domainContact);

            await _contactRepository.SaveChangesAsync();

            return domainContact;
        }
    }
}