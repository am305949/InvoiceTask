
using InvoiceTask.Data.Repository.CategoryRepository;
using InvoiceTask.Data.Repository.InvoiceRepository;
using InvoiceTask.Data.Repository.ProductRepository;

namespace InvoiceTask.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
    }
}
