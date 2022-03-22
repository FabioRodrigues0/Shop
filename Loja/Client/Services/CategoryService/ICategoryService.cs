namespace Loja.Client.Services.CategoryService
{
	public interface ICategoryService
	{
		List<Category> Categories{ get; set; }
		Task<List<Category>> GetCategories();
	}
}
