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
    public class CupomVM
    {
        public CupomVM()
        {
            this.Estacionamentos = new List<SelectListItem>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Cupom: ")]
        [StringLength(50, MinimumLength = 5, ErrorMessage =
            "Deve ter no mínimo 5 e no máximo 50 caracteres.")]
        [Display(Name = "Placa do veiculo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Porcentagem")]
        [Display(Name = "Porcentagem: ")]
        public string Descricao { get; set; }

        public List<SelectListItem> Estacionamentos { get; set; }

        [Display(Name = "Estacionamento: ")]
        [Required(ErrorMessage = "Estacionamento")]
        public long IdCursoSelecionado { get; set; }
    }
}
