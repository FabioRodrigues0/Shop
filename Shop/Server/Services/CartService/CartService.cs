namespace Shop.Server.Services.CartService;

public class CartService : ICartService
{
	private readonly DataContext _context;
	public CartService(DataContext context)
	{
		_context = context;
	}

	public async Task<ServiceResponse<List<CartItens>>> GetCartItensAsync()
	{
		var response = new ServiceResponse<List<CartItens>>()
		{
			Data = await _context.CartItens.ToListAsync()
		};	
		return response;
	}

	public CartItens AddProduct(Product request)
	{
		var response = new CartItens();
		response.ProductId = request.Id;
		return response;
	}

	public async Task<ServiceResponse<List<Cart>>> GetCartProducts(List<CartItens> cartItems)
  {
    var result = new ServiceResponse<List<Cart>>
    {
      Data = new List<Cart>()
    };

    foreach(var item in cartItems)
    {
      var product = await _context.Products
          .Where(p => p.Id == item.ProductId)
          .FirstOrDefaultAsync();

      if(product == null)
      {
        continue;
      }

      var cartProduct = new CartItens()
      {
        ProductId = product.Id,
        Price = product.Price,
        Quantity = item.Quantity
      };

      //result.Data.Add();
    }

    return result;
  }
}