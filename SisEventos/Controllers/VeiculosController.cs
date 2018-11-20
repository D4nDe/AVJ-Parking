using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class VeiculosController : Controller
    {

        private Banco db;

        public VeiculosController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Veiculo> veiculos = db.Veiculos.ToList();
            return View(veiculos);
        }
    }
}