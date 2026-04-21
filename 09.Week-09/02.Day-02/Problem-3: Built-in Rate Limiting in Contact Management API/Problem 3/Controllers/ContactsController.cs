/*Week-9 (DAY-1) Hands-On
Problem-3: Built-in Rate Limiting in Contact Management API 
Scenario:
You are developing a Contact Management API exposed to external clients.
The API is facing issues like:
Too many frequent requests from the same client 
Performance bottlenecks 
Risk of misuse or DDoS-like behavior 
Instead of writing custom middleware, you will use the built-in Rate Limiting Middleware introduced in ASP.NET Core (.NET 7/8) to control traffic efficiently.

Requirements:
🔹 Functional Requirements
1.Create a Contact entity with the following fields: 
oContactId (int) 
oName (string) 
oEmail (string) 
oPhone (string) 
2.Implement an API endpoint:
GET /api/contacts
3.Configure Rate Limiting Policy: 
Allow 5 requests per 60 seconds per client 
Use Fixed Window Rate Limiting 
4.Identify client using: 
IP Address 
5.If limit exceeds: 
Return HTTP Status Code: 429 (Too Many Requests) 
Return response message:
"Too many requests. Please try again later."
	

6. Apply rate limiting:
Globally OR 
On specific endpoint (ContactsController)

🔹 Example Behavior
Request	Result
1–5	✅ Allowed
6th	❌ Blocked (429)

Technical Constraints
Use .NET 8 Web API 
Use Built-in Rate Limiting Middleware 
Use FixedWindowLimiter 
Configure in Program.cs 
Expectations
Students should:
Understand built-in middleware usage 
Configure rate limiting policies 
Apply policy to endpoints 
Handle 429 responses properly 
Avoid writing custom middleware
Learning Outcomes
After completing this exercise, students will be able to:
Understand Rate Limiting concepts 
Learn Fixed Window algorithm 
Use built-in ASP.NET Core middleware 
Protect APIs from abuse 
Build production-ready APIs*/

////////////////////////////////////////////////////////////////////////////////////////

using Contact_Management_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("FixedPolicy")]   
public class ContactsController : ControllerBase
{
    private readonly IContactService _service;

    public ContactsController(IContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 5)
    {
        var result = await _service.GetContactsAsync(pageNumber, pageSize);
        return Ok(result);
    }
}