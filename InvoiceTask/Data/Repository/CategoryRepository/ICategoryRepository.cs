using InvoiceTask.Data.Repository.GenericRepository;
using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTask.Data.Repository.CategoryRepository
{
	public interface ICategoryRepository : IGenericRepository<Category>
	{
		Category GetByName(string name);
		Category GetByIdWithAllData(Guid id);
		List<Category> GetAllWithAllData();
	}
}
