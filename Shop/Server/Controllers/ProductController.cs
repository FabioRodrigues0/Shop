using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Shop.Server.Services.ProductService;

namespace Shop.Server.Controllers;

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
	public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
	{
		var result = await _productService.GetProductAsync(productId);
		return Ok(result);
	}
	//[HttpGet("category/{categoryUrl}")]
	//public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
	//{
	//	var result = await _productService.GetProductsByCategory(categoryUrl);
	//	return Ok(result);
	//}
	[HttpPut]
	public async Task<ActionResult<Product>>UpdateProduct(Product product)
	{
		try
		{
			var productToUpdate = await GetProduct(product.Id);
			if (productToUpdate == null)
			{
				return NotFound($"Product with Id = {product.Id} not found");
			}
			return await _productService.UpdateProduct(product);
		}
		catch (Exception)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data");
		}
	}
}