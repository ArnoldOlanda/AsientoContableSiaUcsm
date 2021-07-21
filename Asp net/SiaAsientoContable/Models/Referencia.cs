namespace SiaAsientoContable.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Referencia")]
    public partial class Referencia
    {
        [Key]
        public int cod_tipo { get; set; }

        [Required]
        [StringLength(50)]
        public string des_tipo { get; set; }
    }
}
