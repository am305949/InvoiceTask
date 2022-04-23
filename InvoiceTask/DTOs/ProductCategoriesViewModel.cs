using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InvoiceTask.ViewModels
{
	public class ProductCategoriesViewModel
	{
		public Product Product { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public List<Guid> SelectedCategoriesIds { get; set; } = new List<Guid>() ;
    }
}
