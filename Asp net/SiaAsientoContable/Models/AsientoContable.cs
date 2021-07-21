namespace SiaAsientoContable.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AsientoContable")]
    public partial class AsientoContable
    {
        [Key]
        public int num_asiento { get; set; }

        public int cod_sub { get; set; }

        [Required]
        [StringLength(50)]
        public string fec_asiento { get; set; }

        public int tipo_oper { get; set; }

        public double debe { get; set; }

        public double haber { get; set; }

        public int tipo_ref { get; set; }
    }
}
