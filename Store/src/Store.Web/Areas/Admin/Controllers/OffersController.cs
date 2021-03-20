using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Entities;
using Store.Infrastructure.Data;
using Store.Core.ValueObjects;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Store.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class OffersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OffersController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var offers = _context.Items.Where(i => i.IsOffer == true).ToList();
            return View(offers);
        }

        [HttpPost]
        public PartialViewResult GetItemRow(int id)
        {
            var item = _context.Items.Where(i => i.Id == id).FirstOrDefault();
            return PartialView(item);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["Items"] = _context.Items.Where(i => i.IsOffer == false).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile image, IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                var quantites = form["Quantity"];
                var Ids = form["Id"];
                var offerItems = new List<OfferItem>();
                if(quantites.Count != Ids.Count)
                {
                    return View();
                }


                Item item = new Item();
                item.Name = form["Item.Name"];
                item.Code = form["Item.Code"];
                item.Description = form["Item.Description"];
                item.Price = Convert.ToDouble(form["Item.Price"]);
                item.CategoryId = Convert.ToInt32(form["Item.CategoryId"]);
                string uniqueFileName = null;
                if (image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                    item.Image = uniqueFileName;
                }

                item.IsOffer = true;

                item.Factory = "";
                item.CreationTime = DateTime.Now;
                item.UpdateTime = DateTime.Now;

                _context.Add(item);
                await _context.SaveChangesAsync();

                int id = item.Id;

                int ctr = quantites.Count;
                for (int i = 0; i < ctr; i++)
                {
                    OfferItem offerItem = new OfferItem();
                    offerItem.ContainedItemId = Convert.ToInt32(Ids[i]);
                    offerItem.Quantity = Convert.ToInt32(quantites[i]);
                    offerItem.ItemId = id;
                    _context.Add(offerItem);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        public async Task<int> DeleteAsync(int id)
        {
            var offer = _context.Items.Where(o => o.Id == id).FirstOrDefault();
            var offerItems = _context.OfferItems.Where(oi => oi.ItemId == id).ToList();
            foreach(var offerItem in offerItems)
            {
                _context.Remove(offerItem);
            }
            _context.Remove(offer);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
