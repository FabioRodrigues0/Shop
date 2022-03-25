using Shop.Server.Data;

namespace Shop.Server.Services.ProductService;

public class ProductService : IProductService
{
	private readonly DataContext _context;

	public ProductService(DataContext context)
	{
		_context = context;
	}

	public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
	{
		var response = new ServiceResponse<Product>();
		var product = await _context.Products.AsNoTracking().Where(p=> p.Id == productId).FirstOrDefaultAsync();
		if(product == null)
		{
			response.Success = false;
			response.Message = "Sorry, but this product does not exist";
		}
		else
		{
			//response.Success = true;
			response.Data = product;
		}
		return response;
	}

	public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
	{
		var response = new ServiceResponse<List<Product>>()
		{
			Data = await _context.Products.ToListAsync()
		};
		//response.Success = true;
		return response;
	}
	public async Task<ServiceResponse<List<ProductsView>>> GetProductsViewAsync()
	{
		var response = new ServiceResponse<List<ProductsView>>()
		{
			Data = await _context.ProductsView.ToListAsync()
		};
		//response.Success = true;
		return response;
	}

	public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
	{
		var response = new ServiceResponse<List<Product>>
		{
			Data = await _context.Products
				.Where(p => p.Category.CategoryUrl.ToLower().Equals(categoryUrl.ToLower()))
				.ToListAsync()
		};
		//response.Success = true;
		return response;
	}

	public async Task<Product> UpdateProduct(Product request)
	{
		_context.Update(request);
		await _context.SaveChangesAsync();

		return request;
	}
}