using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Shared;

public class ProductsView
{
	public int Id { get; set; }
	public string ProductName { get; set; }
	public int Barcode { get; set; }
	public int Stock { get; set; }
	public decimal Price { get; set; }
	public int Tax { get; set; }
	public string Category { get; set; }
	public string Brand { get; set; }
}