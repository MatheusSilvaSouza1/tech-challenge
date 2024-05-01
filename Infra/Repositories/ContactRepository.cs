using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ContactRepository(Context context) : IContactRepository
    {
        private readonly Context _context = context;

        public void Create(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public async Task<DDD?> FindDDD(int dddId)
        {
            return await _context.DDDs.FirstOrDefaultAsync(e => e.Id == dddId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}