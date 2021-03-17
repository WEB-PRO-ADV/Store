using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Core.Interfaces;
using Store.Core.ValueObject;
using Store.Infrastructure.Data;

namespace Store.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SupplierCategoriesController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly AppDbContext _context;

        public SupplierCategoriesController(AppDbContext context, ISupplierService supplierService)
        {
            _context = context;
            _supplierService = supplierService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //string res = await _supplierService.GetCategoriesAsync();
            //res = res.ToString();
            //var categories = JsonConvert.DeserializeObject<List<SupplierCategoryValueObject>>(res);
            var categories = await _supplierService.GetCategoriesAsync();
            return View(categories);
        }
    }
}
