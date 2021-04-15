using Gmlu.Demo.EntityFramework.DataContext;
using Gmlu.Demo.EntityFramework.Models;
using Gmlu.Demo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gmlu.Demo.Web.Controllers
{
    public class RaspberryController : Controller
    {
        private readonly StatsContext _context;

        public RaspberryController(
            StatsContext context)
        {
            _context = context;
        }


        // GET: RaspberryController
        public ActionResult Index()
        {
            return View(_context.Raspberrys);
        }


        // GET: RaspberryController/Create
        public ActionResult Create()
        {
            var viewModel = new RaspberryCreateViewModel();
            return View(viewModel);
        }

        // POST: RaspberryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RaspberryCreateViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newModel);
            }

            try
            {
                var newEntity = new Raspberry();
                newEntity.Name = newModel.Name;
                newEntity.location = newModel.Location;
                newEntity.IPadress = newModel.IPadress;
                newEntity.RaspberryId = Guid.NewGuid();
                _context.Raspberrys.Add(newEntity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", newModel);
            }
        }


        // GET: RaspberryController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var entity = _context.Raspberrys.Find(id);
            RaspberryEditViewModel viewModel = new RaspberryEditViewModel()
            {
                RaspberryId = entity.RaspberryId,
                IPadress = entity.IPadress,
                Location = entity.location,
                Name = entity.Name
            };
            return View(viewModel);
        }

        // POST: RaspberryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRaspberryChange(RaspberryEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            var entity = _context
                .Raspberrys
                .Find(
                    model.RaspberryId);

            entity.Name = model.Name;
            entity.location = model.Location;
            entity.IPadress = model.IPadress;

            _context.Raspberrys.Update(entity);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // GET: RaspberryController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var entity = _context.Raspberrys.Find(id);
            RaspberryEditViewModel viewModel = new RaspberryEditViewModel()
            {
                RaspberryId = entity.RaspberryId,
                IPadress = entity.IPadress,
                Location = entity.location,
                Name = entity.Name
            };

            return View(viewModel);
        }

        // POST: RaspberryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRaspberry(IFormCollection form)
        {
            try
            {
                Guid id = Guid.Parse(form["RaspberryId"]);
                var entity = _context.Raspberrys.Find(id);
                _context.Raspberrys.Remove(entity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
