using Microsoft.AspNetCore.Mvc;
using WebApplication6.DataAccess;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _repository.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repository.GetByIdAsync(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactInfo contact)
        {
            if (string.IsNullOrWhiteSpace(contact.FirstName) ||
                string.IsNullOrWhiteSpace(contact.EmailId))
            {
                return BadRequest("FirstName and EmailId are required.");
            }

            var created = await _repository.CreateAsync(contact);

            return CreatedAtAction(nameof(GetById),
                new { id = created.ContactId },
                created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactInfo contact)
        {
            var result = await _repository.UpdateAsync(id, contact);

            if (!result)
                return NotFound();

            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Deleted successfully");
        }
    }
}
