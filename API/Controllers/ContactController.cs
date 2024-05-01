using Domain.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController(IContactServices contactServices) : ControllerBase
{
    private readonly IContactServices _contactServices = contactServices;

    [HttpPost]
    public async Task<IActionResult> Post(ContactDTO contact)
    {
        var result = await _contactServices.CreateContact(contact);
        if (result.ValidationResult.IsValid)
        {
            return Created();
        }

        return BadRequest(result.ValidationResult);
    }
}
