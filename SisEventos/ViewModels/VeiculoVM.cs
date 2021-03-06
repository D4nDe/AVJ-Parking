﻿using Microsoft.AspNetCore.Http;
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

        [StringLength(20, MinimumLength = 5)]
        [Required(ErrorMessage = "É obrigatorio")]
        [Display(Name = "Placa do veiculo")]
        public string Nome { get; set; }


        [StringLength(15, MinimumLength = 2)]
        [Required(ErrorMessage = "Cor")]
        [Display(Name = "Cor: ")]
        public string Descricao { get; set; }

        [StringLength(50, MinimumLength = 5)]
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
