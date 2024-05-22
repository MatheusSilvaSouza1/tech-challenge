using Domain;
using TechChallenge.Tests.Entitiy;

namespace TechChallenge.Tests.Domain
{
    public class ContactTests
    {
        [Fact]
        public void Create_ShouldReturnContact_WhenContactDTOIsValid()
        {
            // Arrange
            var contactDto = ContactBuilder.Build();

            // Act
            var contact = Contact.Create(contactDto);

            // Assert
            Assert.NotNull(contact);
            Assert.Equal(contactDto.Name, contact.Name);
            Assert.Equal(contactDto.Phone, string.Concat(contact.DDDId.ToString(), contact.Phone));
            Assert.Equal(contactDto.Email, contact.Email);
        }

        [Fact]
        public void Create_ShouldHaveValidationErrors_WhenEmailContactDTOIsInvalid()
        {
            // Arrange
            var contactDto = ContactBuilder.Build();
            contactDto.Email = contactDto.Email.Replace("@", "");

            // Act
            var contact = Contact.Create(contactDto);

            // Assert
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.ValidationResult.Errors);
            Assert.True(contact.ValidationResult.Errors.Count() == 1);
            Assert.Equal("'Email' is not a valid email address.", contact.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Create_ShouldHaveValidationErrors_WhenPhoneContactDTOIsInvalid()
        {
            // Arrange
            var contactDto = ContactBuilder.Build();
            contactDto.Phone = contactDto.Phone[3..];

            // Act
            var contact = Contact.Create(contactDto);

            // Assert
            Assert.NotNull(contact);
            Assert.NotEmpty(contact.ValidationResult.Errors);
            Assert.True(contact.ValidationResult.Errors.Count() == 1);
            Assert.Equal("'Phone' number must contain 8 or 9 digits.", contact.ValidationResult.Errors[0].ErrorMessage);
        }
        
    }
}
