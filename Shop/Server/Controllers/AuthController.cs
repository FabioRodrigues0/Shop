using Microsoft.AspNetCore.Mvc;
using Shop.Server.Services.AuthService;

namespace Shop.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
	private readonly IAuthService _authService;
	public static User user = new User();

	public AuthController(IAuthService authService)
	{
		_authService = authService;
	}

	[HttpPost("register")]
	public async Task<ActionResult<User>> Register(UserRegistration request)
	{
		var response = await _authService.Register(
			new User
			{
				Email = request.Email
			},
			request.Password);
		if(!response.Success)
		{
			return BadRequest(response);
		}
		return Ok(response);
	}

	[HttpPost("login")]
	public async Task<ActionResult<string>> login(UserLogin request)
	{
		var response = await _authService.Login(request.Email, request.Password);
		if(!response.Success)
		{
			return BadRequest(response);
		}

		return Ok(response);
	}
}