using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Server.Services.TaxService;

namespace Shop.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaxController : ControllerBase
{
	private readonly ITaxService _taxService;

	public TaxController(ITaxService taxService)
	{
		_taxService = taxService;
	}

	[HttpGet]
	public async Task<ActionResult<ServiceResponse<List<Tax>>>> GetTaxes()
	{
		var result = await _taxService.GetTaxes();
		return Ok(result);
	}
}