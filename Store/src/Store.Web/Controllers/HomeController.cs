using Microsoft.AspNetCore.Mvc;
using Store.Core.Entities;
using Store.Core.ValueObjects;
using Store.Infrastructure.Data;
using System.Collections.Generic;
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
            var filterValueObject = new FilterSpecValueObject();
            List<string> NamSpec = new List<string>();
            var items = _context.Items.ToList();
            var itemUniqspecs = _context.ItemUniqueSpecs.ToList();
            bool flag;
            filterValueObject.Price_max = items.Max(x => x.Price);
            foreach (var item in itemUniqspecs)
            {
                flag = NamSpec.Contains(item.Name);
                if (flag == false)
                {
                    NamSpec.Add(item.Name + "");

                }
                else {; }
            }
            filterValueObject.NameSpec = NamSpec;
            filterValueObject.Items = items;
            filterValueObject.ItemUniqueSpecs = itemUniqspecs;

            return View(filterValueObject);
        }

        [HttpPost]
        public IActionResult Index(FilterSpecValueObject filterValueObject, string name)
        {
            List<string> NamSpec = new List<string>();
            List<string> ValSpec = new List<string>();
            List<Item> itemsSelected = new List<Item>();
            var items = _context.Items.ToList();
            var itemUniqspecs = _context.ItemUniqueSpecs.ToList();
            bool flag;
            int prod_id;
            filterValueObject.Namespecefication = name;
            foreach (var item in itemUniqspecs)
            {

                if (item.Name == name)
                {
                    ValSpec.Add(item.Value + "");
                    prod_id = item.ItemId;
                    foreach (var it in items)
                    {
                        if (it.Id == prod_id)
                        {
                            itemsSelected.Add(it);
                        }

                    }
                }

            }
            filterValueObject.Price_max = itemsSelected.Max(x => x.Price);
            foreach (var item in itemUniqspecs)
            {
                flag = NamSpec.Contains(item.Name);
                if (flag == false)
                {
                    NamSpec.Add(item.Name + "");

                }
                else {; }
            }
            filterValueObject.ValueSpec = ValSpec;
            filterValueObject.NameSpec = NamSpec;
            filterValueObject.Items = itemsSelected;
            filterValueObject.ItemUniqueSpecs = itemUniqspecs;


            return View(filterValueObject);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
