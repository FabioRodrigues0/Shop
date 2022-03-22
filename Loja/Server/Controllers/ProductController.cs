using Microsoft.AspNetCore.Mvc;

namespace Loja.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductController(IProductService productService)
	{
		_productService = productService;
	}
	[HttpGet]
	public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
	{
		var result = await _productService.GetProductsAsync();
		return Ok(result);
	}
	[HttpGet("ProductsView")]
	public async Task<ActionResult<ServiceResponse<List<ProductsView>>>> GetProductsView()
	{
		var result = await _productService.GetProductsViewAsync();
		return Ok(result);
	}
	[HttpGet("{productId}")]
	public async Task<ActionResult<ServiceResponse<Product>>> GetProducts(int productId)
	{
		var result = await _productService.GetProductAsync(productId);
		return Ok(result);
	}
	[HttpGet("category/{categoryUrl}")]
	public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
	{
		var result = await _productService.GetProductsByCategory(categoryUrl);
		return Ok(result);
	}
	[HttpPost]
	public async Task<ActionResult<Product>>UpdateProduct(Product request)
	{
		var result = await _productService.UpdateProduct(request);
		return Ok(result);
	}
}