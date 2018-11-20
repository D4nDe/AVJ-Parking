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
    public class EstacionamentosController : BaseAdminController
    {

        private IHostingEnvironment env;

        private String UploadImagem(IFormFile formFile)
        {
            if (formFile != null && formFile.Length != 0)
            {
                string extension = Path.GetExtension(formFile.FileName);
                string fileName = $"{Guid.NewGuid().ToString()}{extension}";
                var path = Path.Combine(env.WebRootPath, "estacionamentos", fileName).ToLower();

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }

                return $"/estacionamentos/{fileName}";
            }

            return null;
        }

        public EstacionamentosController(Banco _db, IHostingEnvironment _env) : base(_db)
        {
            this.env = _env;
        }

        public IActionResult Index()
        {
            List<Estacionamento> estacionamentos = this.db.Estacionamentos.ToList();
            return View(estacionamentos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EstacionamentoVM vm = new EstacionamentoVM();

            var cupons = db.Cupons.ToList();
            foreach (var cupom in cupons)
            {
                vm.Cupons.Add(new SelectListItem
                {
                    Value = cupom.Id.ToString(),
                    Text = cupom.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(EstacionamentoVM vm)
        {
            if (ModelState.IsValid)
            {
                Estacionamento estacionamento = new Estacionamento();
                estacionamento.Nome = vm.Nome;
                estacionamento.Descricao = vm.Descricao;
                estacionamento.CaminhoImagem = this.UploadImagem(vm.Imagem);
                estacionamento.Cupom = db.Cupons.Find(vm.IdCursoSelecionado);
                this.db.Estacionamentos.Add(estacionamento);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            var cupons = db.Cupons.ToList();
            foreach (var cupon in cupons)
            {
                vm.Cupons.Add(new SelectListItem
                {
                    Value = cupon.Id.ToString(),
                    Text = cupon.Nome
                });
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Estacionamento estacionamento = this.db.Estacionamentos
                                   .Include(m => m.Cupom)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            if (estacionamento == null)
            {
                return NotFound();
            }

            EstacionamentoVM vm = new EstacionamentoVM();
            vm.Nome = estacionamento.Nome;
            vm.Descricao = estacionamento.Descricao;
            var cupons = db.Cupons.ToList();
            foreach (var cupon in cupons)
            {
                vm.Cupons.Add(new SelectListItem
                {
                    Value = cupon.Id.ToString(),
                    Text = cupon.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, EstacionamentoVM vm)
        {
            if (ModelState.IsValid)
            {
                Estacionamento estacionamentoDb = this.db.Estacionamentos.Find(id);
                estacionamentoDb.Nome = vm.Nome;
                estacionamentoDb.Descricao = vm.Descricao;
                estacionamentoDb.CaminhoImagem = this.UploadImagem(vm.Imagem);
                estacionamentoDb.Cupom = db.Cupons.Find(vm.IdCursoSelecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Estacionamento estacionamento = this.db.Estacionamentos
                                  .Include(m => m.Cupom)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (estacionamento == null)
            {
                return NotFound();
            }

            return View(estacionamento);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Estacionamento estacionamento = this.db.Estacionamentos
                                  .Include(m => m.Cupom)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (estacionamento == null)
            {
                return NotFound();
            }

            return View(estacionamento);
        }

        [HttpPost]
        public IActionResult Delete(long id, Estacionamento estacionamento)
        {
            Estacionamento estacionamentoDb = this.db.Estacionamentos
                                  .Include(m => m.Cupom)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Estacionamentos.Remove(estacionamentoDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}