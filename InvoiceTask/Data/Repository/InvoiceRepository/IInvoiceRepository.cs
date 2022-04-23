using InvoiceTask.Data.Repository.GenericRepository;
using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTask.Data.Repository.InvoiceRepository
{
	public interface IInvoiceRepository : IGenericRepository<Invoice>
	{
		Invoice GetByUserName(string name);
		Invoice GetByIdWithAllData(Guid id);
		List<Invoice> GetAllWithAllData();
	}
}
