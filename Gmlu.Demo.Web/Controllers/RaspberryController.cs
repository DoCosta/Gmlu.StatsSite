using Gmlu.Demo.EntityFramework.DataContext;
using Gmlu.Demo.EntityFramework.Models;
using Gmlu.Demo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult Create(IFormCollection form)
        {
            try
            {
                var newEntity = new Raspberry();
                newEntity.IPadress = form["IPadress"];
                newEntity.Name = form["Name"];
                newEntity.location = form["Location"];
                newEntity.RaspberryId = Guid.NewGuid();
                _context.Raspberrys.Add(newEntity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: RaspberryController/Edit/5
        public ActionResult Edit (Guid id)
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
        public ActionResult SaveRaspberryChange (IFormCollection form)
        {
            try
            {
                Guid id = Guid.Parse(form["RaspberryId"]);
                var entity = _context.Raspberrys.Find(id);
                entity.IPadress = form["IPadress"];
                entity.Name = form["Name"];
                entity.location = form["Location"];
                _context.Raspberrys.Update(entity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)            
            {
                return View();
            }
        }

        // GET: RaspberryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RaspberryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
