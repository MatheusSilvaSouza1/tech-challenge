using Contracts;
using API.DTOs;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController(IPublishEndpoint _publishEndpoint, IContactServices _contactServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(int? ddd)
    {
        try
        {
            var result = await _contactServices.GetContacts(ddd);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(ContactDTO contact)
    {
        await _publishEndpoint.Publish(new ContactMessage()
        {
            Name = contact.Name,
            Phone = contact.Phone,
            Email = contact.Email
        });
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(ContactUpdateDTO contact)
    {
        await _publishEndpoint.Publish(new ContactUpdateMessage()
        {
            Id = contact.Id,
            Name = contact.Name,
            Phone = contact.Phone,
            Email = contact.Email
        });
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContact(Guid contactId)
    {
        await _publishEndpoint.Publish(new DeleteContactMessage(contactId));

        return Ok();
    }
}

