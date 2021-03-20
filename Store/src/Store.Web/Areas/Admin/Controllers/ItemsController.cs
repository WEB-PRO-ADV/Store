using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Data;

namespace Store.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.Items.Where(i => i.IsOffer == false).ToList();
            return View(items);
        }

        public IActionResult Edit(int id)
        {
            var item = _context.Items.Where(i => i.Id == id).FirstOrDefault();

            return View(item);
        }

        [HttpPost]
        public async Task<int> Delete(int id)
        {
            // to be edited -> remove offers
            var item = _context.Items.Where(i => i.Id == id).FirstOrDefault();
            if(item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
