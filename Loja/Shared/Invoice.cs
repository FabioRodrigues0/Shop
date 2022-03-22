using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Shared;

public class Invoice
{
	public int Id { get; set; }
	public int ClientId { get; set; }
	public List<InvoiceProduct> Products { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal TotalPrice { get; set; }
	public DateTime Date { get; set; }
}