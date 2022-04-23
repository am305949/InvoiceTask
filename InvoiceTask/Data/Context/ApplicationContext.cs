using InvoiceTask.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceTask.Data.Context
{
	public class ApplicationContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
	{
        public ApplicationContext() : base("ApplicationContext") 
		{
			//Calling Custom DB Initializer
			Database.SetInitializer<ApplicationContext>(new CategoryInitializer<ApplicationContext>());
		}

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
		public DbSet<Invoice> Invoices { get; set; }


        //Creating Custom DB Initializer
        public class CategoryInitializer<T> : DropCreateDatabaseIfModelChanges<ApplicationContext>
        {
            protected override void Seed(ApplicationContext context)
            {
                IList<Category> list = new List<Category>();
                //Adding Row
                list.Add(new Category() { Name = "category 1", Description = "first category"});
                list.Add(new Category() { Name = "category 2", Description = "second category" });

                foreach (Category c in list)
                    context.Categories.Add(c);

                context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}