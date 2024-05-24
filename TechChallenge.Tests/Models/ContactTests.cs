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
            Assert.Empty(contact.ValidationResult.Errors);
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

        [Fact]
        public void Update_ShouldUpdateContactDetails()
        {
            // Arrange
            var contact = Contact.Create(new ContactDTO
            {
                Name = "Old Name",
                Phone = "123456789",
                Email = "old@example.com"
            });

            var contactUpdateDto = new ContactUpdateDTO
            {
                Name = "New Name",
                Phone = "34123456789",
                Email = "new@example.com"
            };

            // Act
            contact.Update(contactUpdateDto);

            // Assert
            Assert.Equal("New Name", contact.Name);
            Assert.Equal("123456789", contact.Phone);
            Assert.Equal("new@example.com", contact.Email);
            Assert.Equal(34, contact.DDDId);
        }

        [Fact]
        public void Create_ShouldHaveValidationErrors_WhenDDDIsInvalid()
        {
            // Arrange
            var contactDto = new ContactDTO
            {
                Name = "Jane Doe",
                Phone = "AA123456789", // Invalid DDD
                Email = "jane@example.com"
            };

            // Act
            var contact = Contact.Create(contactDto);

            // Assert
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.ValidationResult.Errors);
            Assert.Contains(contact.ValidationResult.Errors, e => e.PropertyName == "DDDId" && e.ErrorMessage == "'DDD Id' deve ser informado.");
        }

        [Fact]
        public void Update_ShouldThrowException_WhenPhoneIsInvalid()
        {
            // Arrange
            var contact = Contact.Create(new ContactDTO
            {
                Name = "Old Name",
                Phone = "123456789",
                Email = "old@example.com"
            });

            var contactUpdateDto = new ContactUpdateDTO
            {
                Name = "New Name",
                Phone = "invalid-phone",
                Email = "new@example.com"
            };

            // Act & Assert
            Assert.Throws<FormatException>(() => contact.Update(contactUpdateDto));
        }
    }
}
