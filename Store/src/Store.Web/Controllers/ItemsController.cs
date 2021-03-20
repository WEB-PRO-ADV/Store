using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Entities;
using Store.Core.ValueObject;
using Store.Infrastructure.Data;

namespace Store.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        public ItemsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Item(int id)
        {
            Item item = _context.Items.Where(i => i.Id == id).FirstOrDefault();
            var specs = _context.ItemUniqueSpecs.Where(s => s.ItemId == item.Id).ToList();
            ItemValueObject itemValueObject = new ItemValueObject();
            itemValueObject.Item = item;
            itemValueObject.ItemUniqueSpec = specs;
            if (item.IsOffer == true)
            {
                return RedirectToAction("Offer", id);
            }
            return View(itemValueObject);
        }

        public IActionResult Offer(int id)
        {
            Item item = _context.Items.Where(i => i.Id == id).FirstOrDefault();
            if (item.IsOffer == true)
            {
                return RedirectToAction("Item", id);
            }
            return View(item);
        }
    }
}
