using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceTask.Models
{
	public class Product
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }

		public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
	}
}