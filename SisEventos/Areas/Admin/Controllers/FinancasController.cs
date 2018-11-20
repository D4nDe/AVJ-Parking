using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisEventos.Models;
using SisEventos.ViewModels;

namespace SisEventos.Areas.Admin.Controllers
{
    public class FinanciasController : BaseAdminController
    {

        private IHostingEnvironment env;


        public FinanciasController(Banco _db, IHostingEnvironment _env) : base(_db)
        {
            this.env = _env;
        }

        public IActionResult Index()
        {
            List<Financia> financias = this.db.Financias.ToList();
            return View(financias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            FinanciaVM vm = new FinanciaVM();

            var cursos = db.Cursos.ToList();
            foreach (var curso in cursos)
            {
                vm.Cursos.Add(new SelectListItem
                {
                    Value = curso.Id.ToString(),
                    Text = curso.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(FinanciaVM vm)
        {
            if (ModelState.IsValid)
            {
                Financia financia = new Financia();
                financia.Dates = vm.Dates;
                financia.Total = vm.Total;
                this.db.Financias.Add(financia);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Financia financia = this.db.Financias
                                   .Include(m => m.Curso)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            FinanciaVM vm = new FinanciaVM();
            vm.Dates = financia.Dates;
            vm.Total = financia.Total;
            var cursos = db.Cursos.ToList();
            foreach (var curso in cursos)
            {
                vm.Cursos.Add(new SelectListItem
                {
                    Value = curso.Id.ToString(),
                    Text = curso.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, FinanciaVM vm)
        {
            if (ModelState.IsValid)
            {
                Financia financiaDb = this.db.Financias.Find(id);
                financiaDb.Dates = vm.Dates;
                financiaDb.Total = vm.Total;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Financia financia = this.db.Financias
                                  .Include(m => m.Curso)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (financia == null)
            {
                return NotFound();
            }

            return View(financia);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Financia financia = this.db.Financias
                                  .Include(m => m.Curso)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (financia == null)
            {
                return NotFound();
            }

            return View(financia);
        }

        [HttpPost]
        public IActionResult Delete(long id, Financia financia)
        {
            Financia financiaDb = this.db.Financias
                                  .Include(m => m.Curso)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Financias.Remove(financiaDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}