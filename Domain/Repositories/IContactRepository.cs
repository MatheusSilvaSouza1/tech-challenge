namespace Domain.Repositories
{
    public interface IContactRepository
    {
        void Create(Contact contact);
        Task SaveChangesAsync();
    }
}