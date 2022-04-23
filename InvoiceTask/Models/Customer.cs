using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTask.Models
{
	public class Customer : ApplicationUser
	{
		public string Name { get; set; }
		public string Address { get; set; }
	}
}