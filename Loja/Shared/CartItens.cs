using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Shared;

public class CartItens
{
	public int ProductId { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal Quantity { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal Price { get; set; }
}