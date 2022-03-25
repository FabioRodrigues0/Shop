namespace Shop.Client.Services.BrandService;

public class BrandService : IBrandService
{
	private readonly HttpClient _http;

	public BrandService(HttpClient http)
	{
		_http = http;
	}

	public List<Brand> Brands { get; set; } = new List<Brand>();

	public async Task<List<Brand>> GetBrands()
	{
		var response =
			await _http.GetFromJsonAsync<ServiceResponse<List<Brand>>>("api/Brand");
		if (response == null && response.Data != null) 
			response.Success = true;
		Brands = response.Data;
		return Brands;
	}
}