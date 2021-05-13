using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthorizationInDotNet5.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionBasedAuthorizationInDotNet5.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Permissions.Products.Edit)]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
