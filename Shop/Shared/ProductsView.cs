using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Shared;

public class ProductsView
{
	public int Id { get; set; }
	public string ProductName { get; set; }
	public int Barcode { get; set; }
	public int Stock { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal Price { get; set; }
	public int Tax { get; set; }
	public string Category { get; set; }
	public string Brand { get; set; }
	public string ImageUrl { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal Descont { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal PriceFinal { get; set; }
}