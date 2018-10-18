using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeInChilThings.Domain;
using TradeInChilThings.Domain.Abstract;

namespace komssionka.Controllers
{
    public class CatalogController : Controller
    {
        private IThingRepository repository;
        public CatalogController(IThingRepository repo)
        {
            repository = repo;
        }
        public ActionResult List(string category)
        {
            IEnumerable<Thing> thing = repository.GetAllThings
                .Where(x => x.Category.Name == category||category==null)
                .Include("Category")
                .Include("Images");
            return PartialView(thing);
        }

        public ViewResult Catalog(string category)
        {
            IEnumerable<Thing> thing = repository.GetAllThings
                .Where(x => x.Category.Name == category || category == null)
                .Include("Category")
                .Include("Images");
            return View(thing);
        }
        public ActionResult Menu()
        {
            IEnumerable<string> Categoryes = repository.GetAllThings.Select(c => c.Category.Name);
            return PartialView(Categoryes);
        }

        public ViewResult Delivery()
        {

            return View();
        }

    }
}