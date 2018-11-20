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

        [Required]
        [Display(Name = "Dia / mês / ano: ")]
        [DisplayFormat(DataFormatString = "Dia/mês/ano: ")]
        public string Dates { get; set; }

        [DisplayFormat(DataFormatString = "Total no caixa: ")]
        [Display(Name = "Total no caixa: ")]
        public string Total { get; set; }

        [Display(Name = "Estacionamento: ")]
        public virtual Estacionamento estacionamento { get; set; }

        [Display(Name = "Foto: ")]
        public String CaminhoImagem { get; set; }

    }
}
