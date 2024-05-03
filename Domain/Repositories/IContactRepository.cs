
namespace Domain.Repositories
{
    public interface IContactRepository
    {
        void Create(Contact contact);
        Task<Contact?> FindContact(Guid id);
        Task<DDD?> FindDDD(int dDD);
        Task SaveChangesAsync();
        void Update(Contact domainContact);
    }
}