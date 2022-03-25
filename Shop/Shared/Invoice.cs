using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Shared;

public class Invoice
{
	public int Id { get; set; }
	public User User { get; set; }
	[ForeignKey("FK_Invoice_UserId_User_Id")]
	public int UserId { get; set; }
	public List<InvoiceProduct> Products { get; set; }
	[Column(TypeName = "decimal(18,2)")]
	public decimal TotalPrice { get; set; }
	public DateTime Date { get; set; }
}