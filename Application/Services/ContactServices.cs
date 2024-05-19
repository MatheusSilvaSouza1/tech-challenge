using Application.Generic;
using Application.NewFolder3;
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

        public async Task<Result<Contact>> DeleteContact(Guid contactId)
        {
            var contactExists = await _contactRepository.FindContact(contactId);

            if (contactExists is null)
            {
                return Result<Contact>.Failure(new ValidationFailure("Contact", "O contato não existe para ser atualizado"));
            }

            _contactRepository.Delete(contactExists);

            await _contactRepository.SaveChangesAsync();

            return Result<Contact>.Success(contactExists);
        }

        public async Task<List<ContactGetDTO>> GetContacts(int? ddd)
        {
            var contacts = ddd is null ? 
                await _contactRepository.FindAllContacts() : 
                await _contactRepository.FindContactsByDDD((int)ddd);

            foreach (var contact in contacts)
            {
                contact.DDD = await _contactRepository.FindDDD(contact.DDDId);
            }

            return contacts.ToDTOList();
        }

        public async Task<Result<Contact>> UpdateContact(ContactUpdateDTO contact)
        {
            var contactExists = await _contactRepository.FindContact(contact.Id);

            if (contactExists is null)
            {
                return Result<Contact>.Failure(new ValidationFailure("Contact", "O contato não existe para ser atualizado"));
            }

            contactExists.Update(contact);

            var ddd = await _contactRepository.FindDDD(contactExists.DDDId);

            if (ddd is null)
            {
                return Result<Contact>.Failure(new ValidationFailure("DDD", "DDD invalido"));
            }

            await _contactRepository.SaveChangesAsync();

            return Result<Contact>.Success(contactExists);
        }
    }
}