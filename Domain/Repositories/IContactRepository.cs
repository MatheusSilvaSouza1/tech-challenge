namespace Domain.Repositories
{
    public interface IContactRepository
    {
        void Create(Contact contact);
        Task<DDD?> FindDDD(int dDD);
        Task SaveChangesAsync();
    }
}