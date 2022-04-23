using InvoiceTask.Data.Repository.CategoryRepository;
using InvoiceTask.Data.Repository.InvoiceRepository;
using InvoiceTask.Data.Repository.ProductRepository;
using InvoiceTask.Data.UnitOfWork;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace InvoiceTask
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IInvoiceRepository, InvoiceRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}