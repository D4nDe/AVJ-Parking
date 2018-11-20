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
    public class VeiculosController : BaseAdminController
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

                return $"/veiculos/{fileName}";
            }

            return null;
        }

        public VeiculosController(Banco _db, IHostingEnvironment _env) : base(_db)
        {
            this.env = _env;
        }

        public IActionResult Index()
        {
            List<Veiculo> veiculos = this.db.Veiculos.ToList();
            return View(veiculos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            VeiculoVM vm = new VeiculoVM();

            var clientes = db.Clientes.ToList();
            foreach (var cliente in clientes)
            {
                vm.Clientes.Add(new SelectListItem
                {
                    Value = cliente.Id.ToString(),
                    Text = cliente.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(VeiculoVM vm)
        {
            if (ModelState.IsValid)
            {
                Veiculo veiculo = new Veiculo();
                veiculo.Nome = vm.Nome;
                veiculo.Descricao = vm.Descricao;
                veiculo.Modelo = vm.Modelo;
                veiculo.cliente = db.Clientes.Find(vm.IdCursoSelecionado);
                this.db.Veiculos.Add(veiculo);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            var clientes = db.Clientes.ToList();
            foreach (var cliente in clientes)
            {
                vm.Clientes.Add(new SelectListItem
                {
                    Value = cliente.Id.ToString(),
                    Text = cliente.Nome
                });
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Veiculo veiculo = this.db.Veiculos
                                   .Include(m => m.cliente)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            if (veiculo == null)
            {
                return NotFound();
            }

            VeiculoVM vm = new VeiculoVM();
            vm.Nome = veiculo.Nome;
            vm.Descricao = veiculo.Descricao;
            vm.Modelo = veiculo.Modelo;
            var clientes = db.Clientes.ToList();
            foreach (var cliente in clientes)
            {
                vm.Clientes.Add(new SelectListItem
                {
                    Value = cliente.Id.ToString(),
                    Text = cliente.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, VeiculoVM vm)
        {
            if (ModelState.IsValid)
            {
                Veiculo veiculoDb = this.db.Veiculos.Find(id);
                veiculoDb.Nome = vm.Nome;
                veiculoDb.Descricao = vm.Descricao;
                veiculoDb.Modelo = vm.Modelo;
                veiculoDb.cliente = db.Clientes.Find(vm.IdCursoSelecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Veiculo veiculos = this.db.Veiculos
                                  .Include(m => m.cliente)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (veiculos == null)
            {
                return NotFound();
            }

            return View(veiculos);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Veiculo veiculos = this.db.Veiculos
                                  .Include(m => m.cliente)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (veiculos == null)
            {
                return NotFound();
            }

            return View(veiculos);
        }

        [HttpPost]
        public IActionResult Delete(long id, Veiculo veiculo)
        {
            Veiculo veiculoDb = this.db.Veiculos
                                  .Include(m => m.cliente)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Veiculos.Remove(veiculoDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}