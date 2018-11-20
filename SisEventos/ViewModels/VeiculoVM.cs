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
    public class VeiculoVM
    {
        public VeiculoVM()
        {
            this.Clientes = new List<SelectListItem>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Placa: ")]
        [StringLength(50, MinimumLength = 5, ErrorMessage =
            "Deve ter no mínimo 5 e no máximo 50 caracteres.")]
        [Display(Name = "Placa do veiculo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cor")]
        [Display(Name = "Cor: ")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Modelo")]
        [Display(Name = "Modelo: ")]
        public string Modelo { get; set; }

        [Display(Name = "Foto: ")]
        public IFormFile Imagem { get; set; }

        public List<SelectListItem> Clientes { get; set; }

        [Display(Name = "Cliente: ")]
        [Required(ErrorMessage = "Cliente")]
        public long IdCursoSelecionado { get; set; }
    }
}
