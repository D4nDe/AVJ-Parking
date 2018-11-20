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
    public class VagasController : BaseAdminController
    {
        
        private IHostingEnvironment env;

        private String UploadImagem(IFormFile formFile)
        {
            if(formFile != null && formFile.Length != 0)
            {
                string extension = Path.GetExtension(formFile.FileName);
                string fileName = $"{Guid.NewGuid().ToString()}{extension}";
                var path = Path.Combine(env.WebRootPath, "eventos", fileName).ToLower();

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }

                return $"/eventos/{fileName}";
            }

            return null;
        }

        public VagasController(Banco _db, IHostingEnvironment _env): base(_db)
        {
            this.env = _env;
        }

        public IActionResult Index()
        {
            List<Vaga> eventos = this.db.Vagas.ToList();
            return View(eventos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            VagaVM vm = new VagaVM();

            var cursos = db.Estacionamentos.ToList();
            foreach(var curso in cursos)
            {
                vm.Estacionamentos.Add(new SelectListItem
                {
                    Value = curso.Id.ToString(),
                    Text = curso.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(VagaVM vm)
        {
            if(ModelState.IsValid)
            {
                Vaga evento = new Vaga();
                evento.Nome = vm.Nome;
                evento.Descricao = vm.Descricao;
                evento.Valor = vm.Valor;
                evento.Estacionamento = db.Estacionamentos.Find(vm.IdCursoSelecionado);
                this.db.Vagas.Add(evento);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            var cursos = db.Estacionamentos.ToList();
            foreach (var curso in cursos)
            {
                vm.Estacionamentos.Add(new SelectListItem
                {
                    Value = curso.Id.ToString(),
                    Text = curso.Nome
                });
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Vaga evento = this.db.Vagas
                                   .Include(m => m.Estacionamento)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            if (evento == null)
            {
                return NotFound();
            }

            VagaVM vm = new VagaVM();
            vm.Nome = evento.Nome;
            vm.Descricao = evento.Descricao;
            vm.Valor = evento.Valor;
            var cursos = db.Estacionamentos.ToList();
            foreach (var curso in cursos)
            {
                vm.Estacionamentos.Add(new SelectListItem
                {
                    Value = curso.Id.ToString(),
                    Text = curso.Nome
                });
            }
            vm.IdCursoSelecionado = evento.Estacionamento.Id;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, VagaVM vm)
        {
            if (ModelState.IsValid)
            {
                Vaga eventoDb = this.db.Vagas.Find(id);
                eventoDb.Nome = vm.Nome;
                eventoDb.Descricao = vm.Descricao;
                eventoDb.Valor = vm.Valor;
                eventoDb.Estacionamento = db.Estacionamentos.Find(vm.IdCursoSelecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Vaga evento = this.db.Vagas
                                  .Include(m => m.Estacionamento)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Vaga evento = this.db.Vagas
                                  .Include(m => m.Estacionamento)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        [HttpPost]
        public IActionResult Delete(long id, Vaga evento)
        {
            Vaga eventoDb = this.db.Vagas
                                  .Include(m => m.Estacionamento)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Vagas.Remove(eventoDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}