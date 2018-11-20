using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Estacionamento
    {
        public long Id { get; set; }

        [Display(Name = "Nome: ")]
        public String Nome { get; set; }

        [Display(Name = "Localização: ")]
        public String Descricao { get; set; }

        [Display(Name = "Imagem: ")]
        public String CaminhoImagem { get; set; }


        [Display(Name = "Estacionamento: ")]
        public virtual Cupom Cupom { get; set; }
    }
}
