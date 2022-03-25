namespace Shop.Server.Services.CartService;

public interface ICartService
{
	Task<ServiceResponse<List<CartItens>>> GetCartItensAsync();
	CartItens AddProduct(Product request);
	Task<ServiceResponse<List<Cart>>> GetCartProducts(List<CartItens> cartItems);
}