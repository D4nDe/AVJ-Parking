using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Cupom
    {
        public long Id { get; set; }

        [Display(Name = "Cupom: ")]
        public String Nome { get; set; }

        [Display(Name = "Porcentagem: ")]
        public String Descricao { get; set; }

        [Display(Name = "Cliente: ")]
        public virtual Estacionamento estacionamento { get; set; }
    }
}
