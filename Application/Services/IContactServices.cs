using Domain;
using Domain.DTOs;

namespace Application.Services
{
    public interface IContactServices
    {
        Task<Contact> CreateContact(ContactDTO contact);
        Task<Contact> UpdateContact(ContactUpdateDTO contact);
    }
}