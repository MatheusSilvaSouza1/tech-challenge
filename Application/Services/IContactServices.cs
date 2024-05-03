using Domain;
using Domain.DTOs;

namespace Application.Services
{
    public interface IContactServices
    {
        Task<Contact> CreateContact(ContactDTO contact);
        Task<Guid> DeleteContact(Guid contactId);
        Task<List<ContactGetDTO>> GetContacts(int? ddd);
        Task<Contact> UpdateContact(ContactUpdateDTO contact);
    }
}