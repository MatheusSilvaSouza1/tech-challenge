using Application.Generic;
using Domain;
using Domain.DTOs;

namespace Application.Services
{
    public interface IContactServices
    {
        Task<Contact> CreateContact(ContactDTO contact);
        Task<Guid> DeleteContact(Guid contactId);
        Task<List<ContactGetDTO>> GetContacts(int? ddd);
        Task<Result<Contact>> UpdateContact(ContactUpdateDTO contact);
    }
}