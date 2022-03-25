using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Shared;

public class InvoiceProduct
{
	public int Id { get; set; }
	public Product Product { get; set; }
	[ForeignKey("FK_InvoiceProduct_ProductId_Product_Id")]
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal quantity { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal ProductPrice { get; set; }
}