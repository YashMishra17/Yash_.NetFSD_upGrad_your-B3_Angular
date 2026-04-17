using Microsoft.AspNetCore.Mvc;
using AuthService.Services;
using AuthService.Data;
using AuthService.Models;


namespace AuthService.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthDbContext _context;
    private readonly AuthService.Services.AuthService _authService;

    public AuthController(AuthDbContext context, AuthService.Services.AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    [HttpPost("login")]
    public IActionResult Login(User login)
    {
        var user = _context.Users
            .FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);

        if (user == null)
            return Unauthorized();

        var token = _authService.GenerateToken(user);
        return Ok(new { token });
    }
}