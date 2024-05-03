
namespace Domain.Repositories
{
    public interface IContactRepository
    {
        void Create(Contact contact);
        void Delete(Contact contactId);
        Task<List<Contact>> FindAllContacts();
        Task<Contact?> FindContact(Guid id);
        Task<List<Contact>> FindContactsByDDD(int ddd);
        Task<DDD?> FindDDD(int dDD);
        Task SaveChangesAsync();
        void Update(Contact domainContact);
    }
}