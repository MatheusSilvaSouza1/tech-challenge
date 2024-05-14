using System.Threading.Tasks;
using Domain;
using Infra;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace TechChallenge.Tests.Repositories
{
    public class ContactRepositoryTests
    {
        private readonly DbContextOptions<Context> _dbContextOptions;
        private readonly Context _context;
        private readonly ContactRepository _contactRepository;

        public ContactRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "ContactDatabase")
                .Options;
            _context = new Context(_dbContextOptions);
            _contactRepository = new ContactRepository(_context);
        }

        [Fact]
        public void Create_ShouldAddContact()
        {
            // Arrange
            var contact = new Contact { Name = "John Doe", Phone = "12123456789", Email = "john@example.com" };

            // Act
            _contactRepository.Create(contact);
            _context.SaveChanges();

            // Assert
            var addedContact = _context.Contacts.Find(contact.Id);
            Assert.NotNull(addedContact);
            Assert.Equal(contact.Name, addedContact.Name);
        }

        [Fact]
        public async Task FindDDD_ShouldReturnDDD_WhenExists()
        {
            // Arrange
            var ddd = new DDD(12) { Region = "Some Region" };
            _context.DDDs.Add(ddd);
            await _context.SaveChangesAsync();

            // Act
            var result = await _contactRepository.FindDDD(12);

            // Assert
            Assert.Equal(ddd, result);
        }

        [Fact]
        public async Task SaveChangesAsync_ShouldCallSaveChangesAsync()
        {
            // Act
            await _contactRepository.SaveChangesAsync();

            // Assert
            // Since SaveChangesAsync doesn't return a value, just verify it completed without exception
            Assert.True(true);
        }
    }
}
