using Domain;
using Domain.DTOs;
using FluentValidation.Results;
using Xunit;

namespace TechChallenge.Tests.Domain
{
    public class ContactTests
    {
        [Fact]
        public void Create_ShouldReturnContact_WhenContactDTOIsValid()
        {
            // Arrange
            var contactDto = new ContactDTO
            {
                Name = "John Doe",
                Phone = "12123456789",
                Email = "john@example.com"
            };

            // Act
            var contact = Contact.Create(contactDto);

            // Assert
            Assert.NotNull(contact);
            Assert.Equal("John Doe", contact.Name);
            Assert.Equal("123456789", contact.Phone);
            Assert.Equal("john@example.com", contact.Email);
            Assert.Equal(12, contact.DDDId);
        }

        [Fact]
        public void Create_ShouldHaveValidationErrors_WhenContactDTOIsInvalid()
        {
            // Arrange
            var contactDto = new ContactDTO
            {
                Name = "John Doe",
                Phone = "invalid-phone",
                Email = "invalid-email"
            };

            // Act
            var contact = Contact.Create(contactDto);

            // Assert
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.ValidationResult.Errors);
        }
    }
}
