using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Shared;
public class User
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string CCNumber { get; set; } = string.Empty;
	public int NIF { get; set; }
	public int PhoneNumber { get; set; }
	public string Email { get; set; }
	public byte[] PasswordHash { get; set; }
	public byte[] PasswordSalt { get; set; }
	public DateTime DateCreated { get; set; } = DateTime.Now;
	public string Role { get; set; } = "Customer";
	public bool Visible { get; set; } = true;
	public bool Deleted { get; set; } = false;
	[NotMapped]
	public bool Editing { get; set; } = false;
	[NotMapped]
	public bool IsNew { get; set; } = false;
}