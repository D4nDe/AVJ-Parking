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
    public class FinanciaVM
    {
        public FinanciaVM()
        {
            this.Estacionamentos = new List<SelectListItem>();
        }

        public long Id { get; set; }

        [Required]
        [Display(Name = "Dia / mês / ano: ")]
        [DisplayFormat(DataFormatString = "Dia/mês/ano: ")]
        public string Dates { get; set; }


        [Required(ErrorMessage = "Total no caixa: ")]
        [Display(Name = "Total no caixa: ")]
        public string Total { get; set; }

        [Display(Name = "Foto: ")]
        public IFormFile Imagem { get; set; }

        public List<SelectListItem> Estacionamentos { get; set; }

        [Display(Name = "Estacionamento: ")]
        [Required(ErrorMessage = "Estacionamento")]
        public long IdCursoSelecionado { get; set; }

    }
}
