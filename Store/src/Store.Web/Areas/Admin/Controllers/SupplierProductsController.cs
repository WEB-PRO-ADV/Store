using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;
using Store.Core.ValueObject;
using Newtonsoft.Json;
using Store.Core.Entities;

namespace Store.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SupplierProductsController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly AppDbContext _context;
        public SupplierProductsController(AppDbContext context, ISupplierService supplierService)
        {
            _context = context;
            _supplierService = supplierService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var products = await _supplierService.GetItemsAsync();
            foreach(var product in products)
            {
                var tmp = _context.Items.Where(i => i.Code == product.Code).Count();
                if(tmp > 0)
                {
                    product.IsAdded = true;
                }
            }
            return View(products);
        }

        public async Task<IActionResult> DetailsAsync(string code)
        {
            var product = await _supplierService.GetItemByCodeAsync(code);
            return View(product);
        }

        [HttpPost]
        public async Task<bool> AddAsync(string code, double price)
        {
            try
            {
                var product = await _supplierService.GetItemByCodeAsync(code);

                var item = new Item();
                item.Name = product.Name;
                item.Price = price;
                item.Image = product.ImgUrl;
                item.Factory = product.Factory;
                item.Description = product.Description;
                item.IsOffer = false;
                item.CategoryId = 1;
                item.Code = code;

                _context.Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public async Task<bool> RemoveAsync(string code)
        {
            try
            {
                var item = _context.Items.Where(i => i.Code == code).FirstOrDefault();

                if (item != null)
                    _context.Remove(item);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public PartialViewResult ChangeProductStatus(string code, double price, bool isAdded)
        {
            ViewData["Code"] = code;
            ViewData["Price"] = price;
            ViewData["IsAdded"] = isAdded;
            return PartialView();
        }

    }
}
