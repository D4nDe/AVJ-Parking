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

        [Display(Name = "Endereço: ")]
        public virtual Curso Curso { get; set; }

        [Display(Name = "Endereço: ")]
        public String Endereco { get; set; }

        [Display(Name = "Foto: ")]
        public String CaminhoImagem { get; set; }

    }
}
