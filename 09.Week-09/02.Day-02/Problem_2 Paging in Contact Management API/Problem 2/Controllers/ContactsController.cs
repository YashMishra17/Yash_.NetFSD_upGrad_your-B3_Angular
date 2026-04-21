/*Week-9 (DAY-1) Hands-On
Problem-2: Paging in Contact Management API 
Scenario:
You are developing a Contact Management System API for an organization where thousands of contacts are stored.
Currently, when users fetch contacts using the API, all records are returned at once, which:
Impacts performance 
Increases response time 
Causes unnecessary data transfer 
To solve this, you need to implement Paging (Pagination) so that users can retrieve contacts in smaller chunks (pages).

Requirements:
🔹 Functional Requirements
1.Create a Contact entity with the following fields: 
oContactId (int) 
oName (string) 
oEmail (string) 
oPhone (string) 
2.Implement an API endpoint:
GET /api/contacts
3.Add support for paging using query parameters: 
pageNumber (default = 1) 
pageSize (default = 5) 
4.Return paginated data: 
Only required number of records per request 
Based on page number and size 




5.Include metadata in response: 
Total Records 
Total Pages 
Current Page 
Page Size

🔹 Example Request
GET /api/contacts?pageNumber=2&pageSize=3

🔹 Example Response
{
  "totalRecords": 10,
  "totalPages": 4,
  "currentPage": 2,
  "pageSize": 3,
  "data": [
    {
      "contactId": 4,
      "name": "John",
      "email": "john@test.com",
      "phone": "9999999999"
    },
    {
      "contactId": 5,
      "name": "Sara",
      "email": "sara@test.com",
      "phone": "8888888888"
    }
  ]
}
Technical Constraints
Use .NET 6/7/8 Web API 
Use Entity Framework Core (Code First) 
Use SQL Server 
Use LINQ methods: 
Skip() 
Take() 
Use Asynchronous methods (async/await)
Expectations
Students should:
Implement paging logic correctly 
Handle default values for query parameters 
Return structured API response with metadata 
Follow clean coding practices 
Use dependency injection
Learning Outcomes
After completing this exercise, students will be able to:
Understand Pagination in Web APIs 
Improve API performance using paging 
Use LINQ Skip & Take effectively 
Design scalable APIs 
Structure API responses professionally 
Apply real-world API optimization techniques */

////////////////////////////////////////////////////////////////////////////////////////

using Contact_Management_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            var result = await _service.GetContactsAsync(pageNumber, pageSize);
            return Ok(result);
        }
    }

}

