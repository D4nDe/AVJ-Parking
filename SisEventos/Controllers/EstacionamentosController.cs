using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class EstacionamentosController : Controller
    {

        private Banco db;

        public EstacionamentosController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Estacionamento> eventos = db.Estacionamentos.ToList();
            return View(eventos);
        }
    }
}