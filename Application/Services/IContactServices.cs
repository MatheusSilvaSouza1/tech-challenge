using Domain.DTOs;

namespace Application.Services
{
    public interface IContactServices
    {
        Task CreateContact(ContactDTO contact);
    }
}