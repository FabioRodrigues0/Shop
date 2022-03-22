using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Shared;

public class Cart
{
	public int ClientId { get; set; }
	public List<CartItens> Items { get; set; }
	public decimal TotalPrice { get; set; }
}