namespace Shop.Server.Services.ProductService;

public interface IProductService
{
	Task<ServiceResponse<List<Product>>>GetProductsAsync();
	Task<ServiceResponse<List<ProductsView>>> GetProductsViewAsync();
	Task<ServiceResponse<Product>>GetProductAsync(int productId);
	Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
	Task<Product> UpdateProduct(Product request);
}