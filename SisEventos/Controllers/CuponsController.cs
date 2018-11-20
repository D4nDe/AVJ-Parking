using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisEventos.Models;

namespace SisEventos.Controllers
{
    public class CuponsController : Controller
    {

        private Banco db;

        public CuponsController(Banco _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            List<Cupom> cupons = db.Cupons.ToList();
            return View(cupons);
        }
    }
}