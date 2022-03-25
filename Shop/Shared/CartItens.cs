using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Shared;

public class CartItens
{
	public int Id { get; set; }
	public Product Product { get; set; }
	[ForeignKey("FK_CartItens_ProductId_Product_Id")]
	public int ProductId { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal Quantity { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal Price { get; set; }
}