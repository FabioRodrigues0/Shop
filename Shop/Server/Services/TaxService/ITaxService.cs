namespace Shop.Server.Services.TaxService;

public interface ITaxService
{
	Task<ServiceResponse<List<Tax>>> GetTaxes();
}