namespace SiaAsientoContable.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanContable")]
    public partial class PlanContable
    {
        [Key]
        [StringLength(50)]
        public string cod_cuenta { get; set; }

        [Required]
        [StringLength(50)]
        public string des_cuenta { get; set; }

        public int cod_jerar { get; set; }

        public int tipo_cuenta { get; set; }

        [Required]
        [StringLength(50)]
        public string ant_jerar { get; set; }
    }
}
