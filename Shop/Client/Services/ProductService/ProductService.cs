namespace Shop.Client.Services.ProductService;

public class ProductService : IProductService
{
	private readonly HttpClient _http;

	public ProductService(HttpClient http)
	{
		_http = http;
	}

	public List<Product> Products { get; set; } = new List<Product>();
	public List<ProductsView> ProductsView { get; set; } = new List<ProductsView>();
	public async Task<List<Product>> GetProducts()
	{
		var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
		if (result != null && result.Data != null)
			Products = result.Data;
		return Products;
	}
	public async Task<List<ProductsView>> GetProductsView()
	{
		var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductsView>>>("api/product/productsview");
		if(result != null && result.Data != null)
			ProductsView = result.Data;
		return ProductsView;
	}

	public async Task<ServiceResponse<Product>> GetProduct(int productId)
	{
		var result =
			await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
		return result;
	}

	public async Task<Product> UpdateProduct(Product request)
	{
		var result = await _http.PutAsJsonAsync("api/Product/", request);
		return await result.Content.ReadFromJsonAsync<Product>();
	}
}