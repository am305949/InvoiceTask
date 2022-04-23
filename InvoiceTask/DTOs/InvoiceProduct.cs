using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceTask.DTOs
{
	public class InvoiceProduct
	{

		[Range(0, int.MaxValue)]
		public int Quantity { get; set; }

		public decimal Price { get; set; }
		public Product Product { get; set; }
	}
}