using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Shared;

public class InvoiceProduct
{
	public int Id { get; set; }
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal quantity { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal ProductPrice { get; set; }
}