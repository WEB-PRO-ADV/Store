using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Entities;
using Store.Core.ValueObjects;
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
            if (item.IsOffer == true)
            {
                return RedirectToAction("Offer", new { id });
            }
            var specs = _context.ItemUniqueSpecs.Where(s => s.ItemId == item.Id).ToList();
            ItemValueObject itemValueObject = new ItemValueObject();
            itemValueObject.Item = item;
            itemValueObject.ItemUniqueSpec = specs;
            
            return View(itemValueObject);
        }

        public IActionResult Offer(int id)
        {
            var offerValueObject = new OfferValueObject();
            var offer = _context.Items.Where(i => i.Id == id).FirstOrDefault();
            if (offer.IsOffer == false)
            {
                return RedirectToAction("Item", new { id });
            }

            var containedItems = _context.OfferItems.Where(oi => oi.ItemId == offer.Id).ToList();

            var offerItems = new List<ItemValueObject>();

            foreach(var containedItem in containedItems)
            {
                ItemValueObject itemValueObject = new ItemValueObject();
                var item = _context.Items.Where(i => i.Id == containedItem.ContainedItemId).FirstOrDefault();
                var specs = _context.ItemUniqueSpecs.Where(s => s.ItemId == item.Id).ToList();
                itemValueObject.Item = item;
                itemValueObject.ItemUniqueSpec = specs;
                offerItems.Add(itemValueObject);
            }

            offerValueObject.Item = offer;
            offerValueObject.OfferItems = offerItems;


            return View(offerValueObject);
        }
    }
}
