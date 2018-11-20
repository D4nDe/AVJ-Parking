using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class EventosController : Controller
    {

        private Banco db;

        public EventosController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Vaga> eventos = db.Vagas.ToList();
            return View(eventos);
        }
    }
}