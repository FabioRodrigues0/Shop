namespace Loja.Client.Services.TaxService;

public interface ITaxService
{
	List<Tax> Taxes{ get; set; }
	Task<List<Tax>> GetTaxes();
}