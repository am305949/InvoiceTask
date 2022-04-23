using InvoiceTask.Data.Context;
using InvoiceTask.Data.Repository.GenericRepository;
using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTask.Data.Repository.ProductRepository
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		private readonly ApplicationContext _context;

		public ProductRepository(ApplicationContext context) : base(context)
		{
			_context = context;
		}

		public List<Product> GetAllWithAllData()
		{
			return _context.Products.ToList();
		}

		public Product GetByIdWithAllData(Guid id)
		{
			return _context.Products.FirstOrDefault(p => p.Id == id);
		}

		public Product GetByName(string name)
		{
			return _context.Products.FirstOrDefault(p => p.Name == name);
		}
	}
}