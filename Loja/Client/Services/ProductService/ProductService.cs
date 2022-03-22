namespace Loja.Client.Services.ProductService;

public class ProductService : IProductService
{
	private readonly HttpClient _http;

	public ProductService(HttpClient http)
	{
		_http = http;
	}

	public List<Product> products { get; set; } = new List<Product>();
	public List<ProductsView> productsView { get; set; } = new List<ProductsView>();
	public async Task<List<Product>> GetProducts()
	{
		var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
		if (result != null && result.Data != null)
			products = result.Data;
		return products;
	}
	public async Task<List<ProductsView>> GetProductsView()
	{
		var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductsView>>>("api/product/productsview");
		if(result != null && result.Data != null)
			productsView = result.Data;
		return productsView;
	}

	public async Task<ServiceResponse<Product>> GetProduct(int productId)
	{
		var result =
			await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
		return result;
	}

	public async Task<Product> SetProduct(Product request)
	{
		var result = await _http.PostAsJsonAsync($"api/Product/{request.Id}", request);
		return await result.Content.ReadFromJsonAsync<Product>();
	}
}