using InvoiceTask.Data.Context;
using InvoiceTask.Data.Repository.GenericRepository;
using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTask.Data.Repository.CategoryRepository
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		private readonly ApplicationContext _context;

		public CategoryRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public List<Category> GetAllWithAllData()
		{
			return _context.Categories.ToList();
		}

		public Category GetByIdWithAllData(Guid id)
		{
			return _context.Categories.FirstOrDefault(c => c.Id == id);
		}

		public Category GetByName(string name)
		{
			return _context.Categories.FirstOrDefault(c => c.Name == name);
		}
	}
}