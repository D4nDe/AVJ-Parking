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
    public class EstacionamentoVM
    {
        public EstacionamentoVM()
        {
            this.Cupons = new List<SelectListItem>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Nome: ")]
        [StringLength(50, MinimumLength = 5, ErrorMessage =
            "O Nome deve ter no mínimo 5 e no máximo 50 caracteres.")]
        [Display(Name = "Nome do estacionamento")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a localização do estacionamento")]
        [Display(Name = "Localização: ")]
        public string Descricao { get; set; }

        [Display(Name = "Imagem de capa: ")]
        public IFormFile Imagem { get; set; }

        public List<SelectListItem> Cupons { get; set; }

        [Display(Name = "Estacionamento: ")]
        [Required(ErrorMessage = "Informe o estacionamento")]
        public long IdCursoSelecionado { get; set; }
    }
}
