using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeInChilThings.Domain;
using TradeInChilThings.Domain.Abstract;

namespace komssionka.Controllers
{
    public class EditController : Controller
    {
        private IThingRepository repository;
        public EditController(IThingRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.GetAllThings.Include(c => c.Category));
        }
        public ViewResult Edit(int Id)
        {
            Thing thing = repository.GetAllThings
            .FirstOrDefault(p => p.Id == Id);
            return View(thing);
        }
        public ViewResult Create(Thing thing)
        {
            return View("Edit", new Thing());
        }

        [HttpPost]
        public ActionResult Edit(Thing thing, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                thing.Images = new List<TradeInChilThings.Domain.Entities.Image>();
                thing.Images.Add(new TradeInChilThings.Domain.Entities.Image { Picture = imageData });
                repository.Save(thing);
                TempData["message"] = string.Format("{0} сохранено!", thing.Name);
                return RedirectToAction("List", "ListThing");
            }
            else
            {
                // there is something wrong with the data values
                return View(thing);
            }
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("List", "ListThing");
        }
    }
}