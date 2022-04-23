using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTask.Models
{
	public class Invoice
	{
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public ICollection<InvoiceDetails> Details { get; set; } = new HashSet<InvoiceDetails>();
    }
}