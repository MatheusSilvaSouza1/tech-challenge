using Domain;
using Domain.DTOs;
using Domain.Repositories;
using FluentValidation.Results;

namespace Application.Services
{
    public class ContactServices(IContactRepository contactRepository) : IContactServices
    {
        private readonly IContactRepository _contactRepository = contactRepository;

        public async Task<Contact> CreateContact(ContactDTO contact)
        {
            var domainContact = Contact.Create(contact);

            var ddd = await _contactRepository.FindDDD(domainContact.DDDId);

            if (ddd is null)
            {
                domainContact.ValidationResult.Errors.Add(new ValidationFailure("DDD", "DDD invalido"));
            }

            if (!domainContact.ValidationResult.IsValid)
            {
                return domainContact;
            }

            _contactRepository.Create(domainContact);

            await _contactRepository.SaveChangesAsync();

            return domainContact;
        }

        public async Task<Contact> UpdateContact(ContactUpdateDTO contact)
        {
            var contactExists = await _contactRepository.FindContact(contact.Id);

            if (contactExists is null)
            {
                throw new Exception("O contato não existe para ser atualizado");
            }

            var domainContact = Contact.Update(contact);

            var ddd = await _contactRepository.FindDDD(domainContact.DDDId);

            if (ddd is null)
            {
                domainContact.ValidationResult.Errors.Add(new ValidationFailure("DDD", "DDD invalido"));
            }

            if (!domainContact.ValidationResult.IsValid)
            {
                return domainContact;
            }

            _contactRepository.Update(domainContact);

            await _contactRepository.SaveChangesAsync();

            return domainContact;
        }
    }
}