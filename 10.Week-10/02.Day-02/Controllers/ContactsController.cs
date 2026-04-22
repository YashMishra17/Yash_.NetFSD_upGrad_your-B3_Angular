using Contact_Management_API.Models;
using ContactManagement.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _service;

    public ContactsController(IContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            return Ok(_service.GetById(id));
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Add(Contact contact)
    {
        try
        {
            _service.Add(contact);
            return StatusCode(201, contact);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Contact contact)
    {
        try
        {
            _service.Update(id, contact);
            return Ok("Updated");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _service.Delete(id);
            return Ok("Deleted");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}