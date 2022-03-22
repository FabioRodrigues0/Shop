using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Shared;

public class Product
{
	public int Id { get; set; }
	[Required, StringLength(20)]
	public string ProductName { get; set; }
	[Required, StringLength(24)]
	public int Barcode { get; set; }
	[Required, StringLength(10)]
	public int Stock { get; set; }
	[Required, Column(TypeName = "decimal(18,2)")]
	public decimal Price { get; set; }
	public Tax Tax { get; set; }
	[Required, ForeignKey("FK_Product_TaxId_Tax_Id")]
	public int TaxId { get; set; }
	public Category Category { get; set; }
	[Required, ForeignKey("FK_Product_CategoryId_Category_Id")]
	public int CategoryId { get; set; }
	public Brand Brand { get; set; }
	[Required, ForeignKey("FK_Product_BrandId_Brand_Id")]
	public int BrandId { get; set; }
	public bool Visible { get; set; } = true;
	public bool Deleted { get; set; } = false;
	[NotMapped]
	public bool Editing { get; set; } = false;
	[NotMapped]
	public bool IsNew { get; set; } = false;
}