namespace Loja.Client.Services.ProductService;

public interface IProductService
{
	List<Product> products { get; set; }
	List<ProductsView> productsView { get; set; }
	Task<List<Product>> GetProducts();
	Task<List<ProductsView>> GetProductsView();
	Task<ServiceResponse<Product>> GetProduct(int productId);
	Task<Product> SetProduct(Product request);
}