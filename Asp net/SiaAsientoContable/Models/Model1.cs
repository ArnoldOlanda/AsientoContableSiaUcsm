using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SiaAsientoContable.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<AsientoContable> AsientoContable { get; set; }
        public virtual DbSet<Operacion> Operacion { get; set; }
        public virtual DbSet<PlanContable> PlanContable { get; set; }
        public virtual DbSet<Referencia> Referencia { get; set; }
        public virtual DbSet<Subdiario> Subdiario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsientoContable>()
                .Property(e => e.fec_asiento)
                .IsUnicode(false);

            modelBuilder.Entity<Operacion>()
                .Property(e => e.des_oper)
                .IsUnicode(false);

            modelBuilder.Entity<PlanContable>()
                .Property(e => e.cod_cuenta)
                .IsUnicode(false);

            modelBuilder.Entity<PlanContable>()
                .Property(e => e.des_cuenta)
                .IsUnicode(false);

            modelBuilder.Entity<PlanContable>()
                .Property(e => e.ant_jerar)
                .IsUnicode(false);

            modelBuilder.Entity<Referencia>()
                .Property(e => e.des_tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Subdiario>()
                .Property(e => e.des_sub)
                .IsUnicode(false);
        }
    }
}
