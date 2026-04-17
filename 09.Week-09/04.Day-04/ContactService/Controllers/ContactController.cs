using Microsoft.AspNetCore.Mvc;
using ContactService.Services;
using ContactService.Models;

namespace ContactService.Controllers;

[ApiController]
[Route("api/contacts")]
public class ContactController : ControllerBase
{
    private readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await _service.GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(Contact contact)
        => Ok(await _service.Add(contact));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Contact contact)
        => Ok(await _service.Update(id, contact));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _service.Delete(id));
}
