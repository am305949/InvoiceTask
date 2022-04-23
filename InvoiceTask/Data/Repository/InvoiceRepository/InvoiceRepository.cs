using InvoiceTask.Data.Context;
using InvoiceTask.Data.Repository.GenericRepository;
using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTask.Data.Repository.InvoiceRepository
{
	public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
	{
		private readonly ApplicationContext _context;

		public InvoiceRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public List<Invoice> GetAllWithAllData()
		{
			return _context.Invoices.ToList();
		}

		public Invoice GetByIdWithAllData(Guid id)
		{
			return _context.Invoices.FirstOrDefault(i => i.Id == id);
		}

		public Invoice GetByUserName(string name)
		{
			return _context.Invoices.FirstOrDefault(i => i.UserName == name);
		}
	}
}