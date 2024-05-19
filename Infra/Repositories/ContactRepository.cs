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

        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public async Task<List<Contact>> FindAllContacts()
        {
            return await _context.Contacts.Include(item => item.DDD).ToListAsync();
        }

        public async Task<Contact?> FindContact(Guid id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<List<Contact>> FindContactsByDDD(int ddd)
        {
            return [.. _context.Contacts.Include(item => item.DDD).Where(e => e.DDDId == ddd)];
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