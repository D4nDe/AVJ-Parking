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
    public class ClientesController : BaseAdminController
    {

        private IHostingEnvironment env;


        public ClientesController(Banco _db, IHostingEnvironment _env) : base(_db)
        {
            this.env = _env;
        }

        public IActionResult Index()
        {
            List<Cliente> clientes = this.db.Clientes.ToList();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ClienteVM vm = new ClienteVM();

            var veiculos = db.Veiculos.ToList();
            foreach (var veiculo in veiculos)
            {
                vm.Veiculos.Add(new SelectListItem
                {
                    Value = veiculo.Id.ToString(),
                    Text = veiculo.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ClienteVM vm)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente();
                cliente.Nome = vm.Nome;
                cliente.Descricao = vm.Descricao;
                cliente.veiculo = db.Veiculos.Find(vm.IdCursoSelecionado);
                this.db.Clientes.Add(cliente);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            var veiculos = db.Veiculos.ToList();
            foreach (var veiculo in veiculos)
            {
                vm.Veiculos.Add(new SelectListItem
                {
                    Value = veiculo.Id.ToString(),
                    Text = veiculo.Nome
                });
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Cliente cliente = this.db.Clientes
                                   .Include(m => m.veiculo)
                                   .Where(x => x.Id == id)
                                   .FirstOrDefault();

            ClienteVM vm = new ClienteVM();
            vm.Nome = cliente.Nome;
            vm.Descricao = cliente.Descricao;
            var veiculos = db.Veiculos.ToList();
            foreach (var veiculo in veiculos)
            {
                vm.Veiculos.Add(new SelectListItem
                {
                    Value = veiculo.Id.ToString(),
                    Text = veiculo.Nome
                });
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(long id, ClienteVM vm)
        {
            if (ModelState.IsValid)
            {
                Cliente clienteDb = this.db.Clientes.Find(id);
                clienteDb.Nome = vm.Nome;
                clienteDb.Descricao = vm.Descricao;
                clienteDb.veiculo = db.Veiculos.Find(vm.IdCursoSelecionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            Cliente cliente = this.db.Clientes
                                  .Include(m => m.veiculo)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            Cliente cliente = this.db.Clientes
                                  .Include(m => m.veiculo)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Delete(long id, Cliente cliente)
        {
            Cliente clienteDb = this.db.Clientes
                                  .Include(m => m.veiculo)
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();

            db.Clientes.Remove(clienteDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}