using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Vaga
    {
        public long Id { get; set; }

        [Display(Name = "Estacionamento: ")]
        public virtual Estacionamento Estacionamento { get; set; }

        [Display(Name= "Vagas: ")]
        public String Nome { get; set; }

        [Display(Name= "Carro ou moto: ")]
        public String Descricao { get; set; }

        [Display(Name= "Valor: ")]
        public string Valor { get; set; }

    }
}
