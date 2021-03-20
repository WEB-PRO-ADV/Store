using Microsoft.AspNetCore.Mvc;
using Store.Core.Entities;
using Store.Infrastructure.Data;
using System.Linq;

namespace Store.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
