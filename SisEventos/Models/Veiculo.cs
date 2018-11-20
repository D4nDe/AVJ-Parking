using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Veiculo
    {
        public long Id { get; set; }

        [Display(Name = "Placa: ")]
        public String Nome { get; set; }

        [Display(Name = "Cor: ")]
        public String Descricao { get; set; }

        [Display(Name = "Modelo: ")]
        public String Modelo { get; set; }

        [Display(Name = "Foto: ")]
        public String CaminhoImagem { get; set; }

        [Display(Name = "Cliente: ")]
        public virtual Cliente cliente { get; set; }
    }
}
