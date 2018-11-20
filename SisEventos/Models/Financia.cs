using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Financia
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Dia/mês/ano: ")]
        [Display(Name = "Dia / mês / ano: ")]
        public string Dates { get; set; }

        [Required(ErrorMessage = "Total no caixa: ")]
        [Display(Name = "Total no caixa: ")]
        public string Total { get; set; }

        [Display(Name = "Endereço: ")]
        public virtual Curso Curso { get; set; }

        [Display(Name = "Foto: ")]
        public String CaminhoImagem { get; set; }

    }
}
