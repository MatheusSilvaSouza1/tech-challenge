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

    [HttpPut]
    public async Task<IActionResult> UpdateContact(ContactUpdateDTO contact)
    {
        try
        {
            var result = await _contactServices.UpdateContact(contact);

            return result.ValidationResult.IsValid ? Ok() : BadRequest(result.ValidationResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteContact(Guid contactId)
    {
        try
        {
            var result = await _contactServices.DeleteContact(contactId);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
