using InvoiceTask.Data;
using InvoiceTask.DTOs;
using InvoiceTask.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InvoiceTask.Controllers
{
    public class CustomerController : Controller
    {
		//private readonly UserManager<ApplicationUser> userManager;

		//public CustomerController(UserManager<ApplicationUser> userManager)
		public CustomerController()
        {
			//this.userManager = userManager;
		}

		private userManager UserManager
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<userManager>();
			}
		}

		// GET: Customer
		public ActionResult Register()
        {
            return View();
        }
        
        // POST: Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterDTO registerCustomer)
        {
            if (ModelState.IsValid == false)
            {
                return View(registerCustomer);
            }
            try
            {
                //save db
                Customer customerModel = new Customer();
                customerModel.UserName = registerCustomer.UserName;
                customerModel.Email = registerCustomer.Email;
                customerModel.PasswordHash = registerCustomer.Password;
                customerModel.Address = registerCustomer.Address;
                IdentityResult result =
                    await UserManager.CreateAsync(customerModel, registerCustomer.Password);
                if (result.Succeeded == true)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            //return View(registerCustomer);
            return RedirectToAction("Customer", "Login");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginDTO loginUser)
        {
            if (ModelState.IsValid == false)
            {
                return View(loginUser);
            }
            ApplicationUser appUser = await UserManager.FindByNameAsync(loginUser.UserName);
            if (appUser != null)
            {
                bool result = await UserManager.CheckPasswordAsync(appUser, loginUser.Password);
                if (result == true)
                {
                    List<Claim> customClaim = new List<Claim>();
                    customClaim.Add(new Claim(ClaimTypes.NameIdentifier, loginUser.UserName));
                    //await SignInManager.SignInWithClaimsAsync(appUser, loginUser.RememberMe, customClaim);
                    return RedirectToAction("AddInvoice", "Invoices");
                }
            }
            ModelState.AddModelError("", "User name & password in correct");
            return View(loginUser);

        }

        public async Task<ActionResult> Signout()
        {

            //await SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}