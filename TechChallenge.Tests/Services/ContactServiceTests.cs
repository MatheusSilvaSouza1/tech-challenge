using System.Threading.Tasks;
using Application.Services;
using Domain.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using API.Controllers;

namespace TechChallenge.Tests.Services
{
    public class ContactControllerTests
    {
        private readonly Mock<IContactServices> _mockContactServices;
        private readonly ContactController _contactController;

        public ContactControllerTests()
        {
            _mockContactServices = new Mock<IContactServices>();
            _contactController = new ContactController(_mockContactServices.Object);
        }

        [Fact]
        public async Task Post_ShouldReturnCreated_WhenContactIsValid()
        {
            // Arrange
            var contactDto = new ContactDTO
            {
                Name = "John Doe",
                Phone = "12123456789",
                Email = "john@example.com"
            };
            var contact = Contact.Create(contactDto);
            var validationResult = new ValidationResult();
            contact.ValidationResult = validationResult;

            _mockContactServices.Setup(service => service.CreateContact(contactDto))
                                .ReturnsAsync(contact);

            // Act
            var result = await _contactController.Post(contactDto);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_WhenContactIsInvalid()
        {
            // Arrange
            var contactDto = new ContactDTO
            {
                Name = "John Doe",
                Phone = "invalid-phone",
                Email = "invalid-email"
            };
            var contact = Contact.Create(contactDto);
            contact.ValidationResult.Errors.Add(new ValidationFailure("Phone", "Invalid phone number"));
            contact.ValidationResult.Errors.Add(new ValidationFailure("Email", "Invalid email address"));

            _mockContactServices.Setup(service => service.CreateContact(contactDto))
                                .ReturnsAsync(contact);

            // Act
            var result = await _contactController.Post(contactDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal(contact.ValidationResult, badRequestResult.Value);
        }
    }
}
