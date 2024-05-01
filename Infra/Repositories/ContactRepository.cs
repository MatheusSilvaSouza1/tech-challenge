using Domain;
using Domain.Repositories;

namespace Infra.Repositories
{
    public class ContactRepository(Context context) : IContactRepository
    {
        private readonly Context _context = context;

        public void Create(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}