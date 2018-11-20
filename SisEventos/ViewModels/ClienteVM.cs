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
    public class ClienteVM
    {
        public ClienteVM()
        {
            this.Cursos = new List<SelectListItem>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Nome: ")]
        [StringLength(50, MinimumLength = 5, ErrorMessage =
            "O Nome deve ter no mínimo 5 e no máximo 50 caracteres.")]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [Display(Name = "CPF: ")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Endereço: ")]
        [Display(Name = "Endereço: ")]
        public string Endereco { get; set; }

        [Display(Name = "Foto: ")]
        public IFormFile Imagem { get; set; }

        public List<SelectListItem> Cursos { get; set; }

    }
}
