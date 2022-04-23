using InvoiceTask.Data.Context;
using InvoiceTask.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTask.Data
{
	public class userManager : UserManager<ApplicationUser>
	{
		public userManager(IUserStore<ApplicationUser> store) : base(store)
		{
		}

        public static userManager Create(IdentityFactoryOptions<userManager> options, IOwinContext context)
        {
            var manager = new userManager(new UserStore<ApplicationUser>(context.Get<ApplicationContext>()));
            
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(2);
            manager.MaxFailedAccessAttemptsBeforeLockout = 3;

            return manager;
        }
    }
}