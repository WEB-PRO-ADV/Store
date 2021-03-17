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
            var items = _context.Items.ToList();
            return View(items);
        }

        public IActionResult Edit(int id)
        {
            var item = _context.Items.Where(i => i.Id == id).FirstOrDefault();

            return View(item);
        }
    }
}
