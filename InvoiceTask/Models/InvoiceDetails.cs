using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceTask.Models
{
	public class InvoiceDetails
	{
		[Key]
		public Guid Id { get; set; }

		[Range(0, int.MaxValue)]
		public int Quantity { get; set; }

		public decimal Price { get; set; }
		public decimal TotalPrice { get; set; }

		[Required]
		[ForeignKey("Product")]
		public Guid ProductId { get; set; }

		public virtual Product Product { get; set; }
		
		[ForeignKey("Invoice")]
		public Guid InvoiceId { get; set; }

		public virtual Invoice Invoice { get; set; }

	}
}