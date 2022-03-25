using Shop.Server.Data;

namespace Shop.Server.Services.TaxService;

public class TaxService : ITaxService
{
	private readonly DataContext _context;

	public TaxService(DataContext context)
	{
		_context = context;
	}
	public async Task<ServiceResponse<List<Tax>>> GetTaxes()
	{
		var taxes = await _context.Taxes.ToListAsync();
		return new ServiceResponse<List<Tax>>
		{
			Data = taxes
		};
	}
}