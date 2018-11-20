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
    public class CuponsController : BaseAdminController
    {

        private IHostingEnvironment env;

        private String UploadImagem(IFormFile formFile)
        {
            if (formFile != null && formFile.Length != 0)
            {
                string extension = Path.GetExtension(formFile.FileName);
                string fileName = $"{Guid.NewGuid().ToString()}{extension}";
                var path = Path.Combine(env.WebRootPath, "veiculos", fileName).ToLower();

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }

                return $"/cupons/{fileName}";
            }

            return null;
        }

        public CuponsController(Banco _db, IHostingEnvironment _env) : base(_db)
        {
            this.env = _env;
        }

        public IActionResult Index()
        {
            List<Cupom> cupons = this.db.Cupons.ToList();
            return View(cupons);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CupomVM vm = new CupomVM();

            var estacionamentos = db.Estacionamentos.ToList();
            foreach (var estacionamento in estacionamentos)
            {
                vm.Estacionamentos.Add(new SelectListItem
                {
                    Value = estacionamento.Id.ToString(),
                    Text = estacionamento.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CupomVM vm)
        {
            if (ModelState.IsValid)
            {
                Cupom cupom = new Cupom();
                cupom.Nome = vm.Nome;
                cupom.Descricao = vm.Descricao;
                cupom.estacionamento = db.Estacionamentos.Find(vm.IdCursoSelecionado);
                this.db.Cupons.Add(cupom);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            var estacionamentos = db.Estacionamentos.ToList();
            foreach (var estacionamento in estacionamentos)
            {
                vm.Estacionamentos.Add(new SelectListItem
                {
                    Value = estacionamento.Id.ToString(),
                    Text = estacionamento.Nome
                });
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Cupom cupons = this.db.Cupons
                                   .Include(m => m.estacionamento)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            if (cupons == null)
            {
                return NotFound();
            }

            CupomVM vm = new CupomVM();
            vm.Nome = cupons.Nome;
            vm.Descricao = cupons.Descricao;
            var estacionamentos = db.Estacionamentos.ToList();
            foreach (var estacionamento in estacionamentos)
            {
                vm.Estacionamentos.Add(new SelectListItem
                {
                    Value = estacionamento.Id.ToString(),
                    Text = estacionamento.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, CupomVM vm)
        {
            if (ModelState.IsValid)
            {
                Cupom cupomDb = this.db.Cupons.Find(id);
                cupomDb.Nome = vm.Nome;
                cupomDb.Descricao = vm.Descricao;
                cupomDb.estacionamento = db.Estacionamentos.Find(vm.IdCursoSelecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Cupom cupons = this.db.Cupons
                                  .Include(m => m.estacionamento)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (cupons == null)
            {
                return NotFound();
            }

            return View(cupons);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Cupom cupons = this.db.Cupons
                                  .Include(m => m.estacionamento)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (cupons == null)
            {
                return NotFound();
            }

            return View(cupons);
        }

        [HttpPost]
        public IActionResult Delete(long id, Cupom cupom)
        {
            Cupom cupomDb = this.db.Cupons
                                  .Include(m => m.estacionamento)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Cupons.Remove(cupomDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}