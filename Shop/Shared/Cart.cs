using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Shared;

public class Cart
{
	public int Id { get; set; }
	public int ClientId { get; set; }
	public List<CartItens> Itens { get; set; }
	[ForeignKey("FK_Cart_ItensId_CartItens_Id")]
	public int ItensId { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal TotalPrice { get; set; }
}