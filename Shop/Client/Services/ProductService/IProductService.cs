namespace Shop.Client.Services.ProductService;

public interface IProductService
{
	List<Product> Products { get; set; }
	List<ProductsView> ProductsView { get; set; }
	Task<List<Product>> GetProducts();
	Task<List<ProductsView>> GetProductsView();
	Task<ServiceResponse<Product>> GetProduct(int productId);
	Task<Product> UpdateProduct(Product request);
}