using InvoiceTask.Data.Context;
using InvoiceTask.Data.UnitOfWork;
using InvoiceTask.DTOs;
using InvoiceTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceTask.Controllers
{
    public class InvoicesController : Controller
    {
		private readonly IUnitOfWork unitOfWork;

		public InvoicesController(IUnitOfWork unitOfWork)
        {
			this.unitOfWork = unitOfWork;
		}


        public ActionResult AddInvoice()
		{
            List<Product> products = unitOfWork.ProductRepository.GetAll();
            ViewBag.Products = products;
            return View();
		}


        [HttpPost]
        public JsonResult AddOrderAndOrderDetials(OrderViewModel orderViewModel)
        {
            bool status = true;

            var isValidModel = TryUpdateModel(orderViewModel);

            if (isValidModel)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Invoice order = new Invoice()
                    {
                        Date = orderViewModel.Date
                    };
                    //unitOfWork.InvoiceRepository.Insert(order);
                    db.Invoices.Add(order);
                    var newOrder = Guid.NewGuid();
                    db.Invoices.Find(order.Id).Id = newOrder;

                    if (db.SaveChanges() > 0)
                    {
                        Guid invoiceID = db.Invoices.Find(order.Id).Id;

                        foreach (var item in orderViewModel.Items)
                        {
                            InvoiceDetails orderDetails = new InvoiceDetails()
                            {
                                InvoiceId = invoiceID,
                                ProductId = item.ProductID,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                TotalPrice = item.TotalPrice
                            };
                            db.InvoiceDetails.Add(orderDetails);

                            var newOrderDetails = Guid.NewGuid();
                            db.InvoiceDetails.Find(orderDetails.Id).Id = newOrderDetails;
                        }


                        if (db.SaveChanges() > 0)
                        {
                            return new JsonResult { Data = new { status = status, message = "Order Added Successfully" } };
                        }
                    }
                }
            }

            status = false;
            return new JsonResult { Data = new { status = status, message = "Error !" } };
        }


        // GET: Invoices
        public ActionResult Checkout()
        {

            return View();
        }
    }
}