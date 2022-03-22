namespace Loja.Client.Services.TaxService;

public class TaxService : ITaxService
{
	private readonly HttpClient _http;

	public TaxService(HttpClient http)
	{
		_http = http;
	}

	public List<Tax> Taxes { get; set; } = new List<Tax>();

	public async Task<List<Tax>> GetTaxes()
	{
		var response =
			await _http.GetFromJsonAsync<ServiceResponse<List<Tax>>>("api/Tax");
		if (response == null && response.Data != null) 
			response.Success = true;
		Taxes = response.Data;
		return Taxes;
	}
}