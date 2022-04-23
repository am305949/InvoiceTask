using InvoiceTask.Data.UnitOfWork;
using InvoiceTask.DTOs;
using InvoiceTask.Models;
using InvoiceTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceTask.Controllers
{
    public class ProductController : Controller
    {
		private readonly IUnitOfWork unitOfWork;

		public ProductController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = unitOfWork.ProductRepository.GetAll();
            return View(products);
        }
        
        // GET: Product
        public ActionResult AllProducts()
        {
            List<Product> products = unitOfWork.ProductRepository.GetAll();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(Guid id)
        {
            Product product = unitOfWork.ProductRepository.GetById(id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var ProductCategoriesVM = new ProductCategoriesViewModel();
            Product product = new Product();
            List<Category> categories = unitOfWork.CategoryRepository.GetAll();
            ProductCategoriesVM.Product = product;
            ProductCategoriesVM.Categories = categories;
            return View(ProductCategoriesVM);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductCategoriesViewModel productCategoriesVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productCategoriesVM.Product.Id = Guid.NewGuid();

                    var newProductCategories = unitOfWork.CategoryRepository.GetAll()
                        .Where(g => productCategoriesVM.SelectedCategoriesIds
                        .Contains(g.Id)).ToList();

                    productCategoriesVM.Product.Categories = newProductCategories;

                    unitOfWork.ProductRepository.Insert(productCategoriesVM.Product);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            List<Category> categories = unitOfWork.CategoryRepository.GetAll();
            productCategoriesVM.Categories = categories;
            return View("Create", productCategoriesVM);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(Guid id)
        {
            var ProductCategoriesVM = new ProductCategoriesViewModel();
            var Product = unitOfWork.ProductRepository.GetByIdWithAllData(id);
            ProductCategoriesVM.Product = Product;
            List<Category> categories = unitOfWork.CategoryRepository.GetAll();
            ProductCategoriesVM.Categories = categories;

            var oldProductCategories = Product.Categories;

            ProductCategoriesVM.SelectedCategoriesIds = oldProductCategories.Select(c => c.Id).ToList();

            return View(ProductCategoriesVM);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, ProductCategoriesViewModel productCategoriesVM)
        {
            if (ModelState.IsValid)
            {
                Product oldProduct = unitOfWork.ProductRepository.GetById(productCategoriesVM.Product.Id);

                var newProductCategories = unitOfWork.CategoryRepository.GetAll()
                        .Where(c => productCategoriesVM.SelectedCategoriesIds
                        .Contains(c.Id)).ToList();

                productCategoriesVM.Product.Categories = newProductCategories;

                unitOfWork.ProductRepository.Update(productCategoriesVM.Product.Id, productCategoriesVM.Product);
                return RedirectToAction("Index");
            }
            return View("Edit", productCategoriesVM);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                unitOfWork.ProductRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

  //      public ActionResult Buy(Guid id)
		//{

		//}
    }
}
