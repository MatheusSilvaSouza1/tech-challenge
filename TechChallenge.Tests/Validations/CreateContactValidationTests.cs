using Domain;
using Domain.Validations;
using FluentValidation.TestHelper;
using Xunit;

namespace TechChallenge.Tests.Domain.Validations
{
    public class CreateContactValidationTests
    {
        private readonly CreateContactValidation _validator;

        public CreateContactValidationTests()
        {
            _validator = new CreateContactValidation();
        }

        [Fact]
        public void ShouldHaveError_WhenEmailIsInvalid()
        {
            // Arrange
            var contact = new Contact { Email = "invalid-email" };

            // Act
            var result = _validator.TestValidate(contact);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Email);
        }

        [Fact]
        public void ShouldHaveError_WhenPhoneIsInvalid()
        {
            // Arrange
            var contact = new Contact { Phone = "invalid-phone" };

            // Act
            var result = _validator.TestValidate(contact);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Phone);
        }

        [Fact]
        public void ShouldNotHaveError_WhenContactIsValid()
        {
            // Arrange
            var contact = new Contact { Email = "john@example.com", Phone = "1234567890" };

            // Act
            var result = _validator.TestValidate(contact);

            // Assert
            result.ShouldNotHaveValidationErrorFor(c => c.Email);
            result.ShouldNotHaveValidationErrorFor(c => c.Phone);
        }
    }
}
