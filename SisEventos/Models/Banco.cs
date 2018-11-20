using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Banco : DbContext
    {
        public Banco(DbContextOptions<Banco> options) : base(options) { }

        public virtual DbSet<Vaga> Vagas { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Estacionamento> Estacionamentos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Financia> Financias { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }
        public virtual DbSet<Cupom> Cupons { get; set; }
        
    }
}
