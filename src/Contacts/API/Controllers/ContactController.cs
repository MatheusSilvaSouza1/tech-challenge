using Contracts;
using API.DTOs;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController(IPublishEndpoint _publishEndpoint) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(int? ddd)
    {
        // try
        // {
        //     var result = await _contactServices.GetContacts(ddd);

        //     return Ok(result);
        // }
        // catch (Exception ex)
        // {
        //     return BadRequest(ex.Message);
        // }
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post(ContactDTO contact)
    {
        // var result = await _contactServices.CreateContact(contact);
        // if (result.ValidationResult.IsValid)
        // {
        //     return Ok(result.Id);
        // }

        // return BadRequest(result.ValidationResult);

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
        // try
        // {
        //     // var result = await _contactServices.UpdateContact(contact);

        //     // return result.IsSuccess ? Ok() : BadRequest(result.ValidationFailure);
        //     return Ok();
        // }
        // catch (Exception ex)
        // {
        //     return BadRequest(ex.Message);
        // }
        await _publishEndpoint.Publish(contact);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContact(Guid contactId)
    {
        // try
        // {
        //     // var result = await _contactServices.DeleteContact(contactId);

        //     return Ok();
        // }
        // catch (Exception ex)
        // {
        //     return BadRequest(ex.Message);
        // }

        await _publishEndpoint.Publish(new DeleteContact(contactId));

        return Ok();
    }
}

