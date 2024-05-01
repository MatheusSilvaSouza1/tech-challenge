using Domain.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PhoneController : ControllerBase
{
    private readonly IContactServices _contactServices;
    public PhoneController(IContactServices contactServices)
    {
        _contactServices = contactServices;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ContactDTO contact)
    {
        await _contactServices.CreateContact(contact);
        return Created();
    }
}
