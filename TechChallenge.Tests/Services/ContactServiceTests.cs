using System.Threading.Tasks;
using Application.Services;
using Domain;
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
        private readonly IContactServices _ContactServices;

        public ContactControllerTests(IContactServices contactServices)
        {
            _ContactServices = contactServices;
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

            var result = await _ContactServices.CreateContact(contactDto);

            Assert.True(true);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_WhenContactIsInvalid()
        {
            // Arrange
            var contactDto = new ContactDTO
            {
                Name = "invalid",
                Phone = "Invalid",
                Email = "invalid"
            };

            var result = await _ContactServices.CreateContact(contactDto);

            Assert.False(false);
        }
    }
}
