
using Domain;
using Domain.DTOs;

namespace Application.NewFolder3
{
    public static class ContactExtension
    {
        public static ContactGetDTO ToDTO(this Contact contact)
        {
            return new ContactGetDTO
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = String.Join("", [contact.DDDId.ToString(), contact.Phone]),
                Region = contact.DDD.Region                
            };
        }
        
        public static List<ContactGetDTO> ToDTOList(this List<Contact> contact)
        {
            var objectToReturn = new List<ContactGetDTO>();

            foreach (var item in contact)
            {
                objectToReturn.Add(item.ToDTO());
            }

            return objectToReturn;            
        }
    }
}
