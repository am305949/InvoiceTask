namespace InvoiceTask.Migrations
{
	using InvoiceTask.Data.Context;
	using InvoiceTask.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "InvoiceTask.Data.Context.ApplicationContext";
        }

        protected override void Seed(ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            IList<Category> list = new List<Category>();
            //Adding Row
            list.Add(new Category() { Name = "category 1", Description = "first category" });
            list.Add(new Category() { Name = "category 2", Description = "second category" });

            foreach (Category c in list)
                context.Categories.Add(c);

            context.SaveChanges();
            base.Seed(context);

        }
    }
}
