namespace SiaAsientoContable.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Operacion")]
    public partial class Operacion
    {
        [Key]
        public int t_oper { get; set; }

        [Required]
        [StringLength(50)]
        public string des_oper { get; set; }
    }
}
