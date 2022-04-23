using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceTask.DTOs
{
	public class RegisterDTO
	{
		[Key]
		[NotMapped]
		public int Id { get; set; }

		[Required(ErrorMessage = "Name Is Required")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Email Is Required")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage ="Passwords Don't Match")]
		public string ConfirmPassword { get; set; }

		public string Address { get; set; }
	}
}
