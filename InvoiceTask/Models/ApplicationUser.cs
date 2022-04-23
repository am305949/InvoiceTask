using InvoiceTask.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace InvoiceTask.Models
{
	public class ApplicationUser : IdentityUser
	{
		internal Task<ClaimsIdentity> GenerateUserIdentityAsync(userManager manager)
		{
			throw new NotImplementedException();
		}
	}
}