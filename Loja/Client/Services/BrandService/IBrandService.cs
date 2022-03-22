namespace Loja.Client.Services.BrandService;

public interface IBrandService
{
	List<Brand> Brands{ get; set; }
	Task<List<Brand>> GetBrands();
}