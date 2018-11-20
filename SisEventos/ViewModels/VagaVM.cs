using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SisEventos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.ViewModels
{
    public class VagaVM
    {
        public VagaVM()
        {
            this.Estacionamentos = new List<SelectListItem>();
        }

        public long Id { get; set; }

        public List<SelectListItem> Estacionamentos { get; set; }

        [Display(Name = "Estacionamento: ")]
        [Required(ErrorMessage = "Informe o estacionamento")]
        public long IdCursoSelecionado { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [Required(ErrorMessage = "Vagas: ")]
        [Display(Name = "Vagas: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Carro ou moto: ")]
        [Display(Name = "Carro ou moto: ")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Valor: ")]
        public string Valor { get; set; }

    }
}
