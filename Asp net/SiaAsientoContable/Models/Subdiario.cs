namespace SiaAsientoContable.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subdiario")]
    public partial class Subdiario
    {
        [Key]
        public int cod_sub { get; set; }

        [Required]
        [StringLength(50)]
        public string des_sub { get; set; }
    }
}
