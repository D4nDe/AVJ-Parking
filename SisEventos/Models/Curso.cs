using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Curso
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do estacionamento: ")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a localização do estacionamento: ")]
        [Display(Name = "Localização: ")]
        public string Descricao { get; set; }
    }
}
