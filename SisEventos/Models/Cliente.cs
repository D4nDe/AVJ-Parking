using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Cliente
    {
        public long Id { get; set; }

        [Display(Name = "Nome: ")]
        public String Nome { get; set; }

        [Display(Name = "CPF: ")]
        public String Descricao { get; set; }

        [Display(Name = "Veiculo: ")]
        public virtual Veiculo veiculo { get; set; }

    }
}
