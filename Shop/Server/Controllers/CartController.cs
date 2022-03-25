using Microsoft.AspNetCore.Mvc;

namespace Shop.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : Controller
{
	private readonly ICartService _cartService;

	public CartController(ICartService cartService)
	{
		_cartService = cartService;
	}
}