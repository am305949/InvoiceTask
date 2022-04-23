using InvoiceTask.Data.Repository.GenericRepository;
using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTask.Data.Repository.ProductRepository
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		Product GetByName(string name);
		Product GetByIdWithAllData(Guid id);
		List<Product> GetAllWithAllData();
	}
}
