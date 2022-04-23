using InvoiceTask.Data.Repository.CategoryRepository;
using InvoiceTask.Data.Repository.InvoiceRepository;
using InvoiceTask.Data.Repository.ProductRepository;

namespace InvoiceTask.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
		public UnitOfWork(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IInvoiceRepository invoiceRepository)
        {
			ProductRepository = productRepository;
			CategoryRepository = categoryRepository;
			InvoiceRepository = invoiceRepository;
		}

		public IProductRepository ProductRepository { get; }

		public ICategoryRepository CategoryRepository { get; }

		public IInvoiceRepository InvoiceRepository { get; }
	}
}
