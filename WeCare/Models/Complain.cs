namespace WeCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Complain")]
    public partial class Complain
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Column("Complain")]
        [Required]
        [StringLength(100)]
        [Display(Name = "Complain Explanation")]
        public string Complain1 { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Address of nearest police station")]
        public string PoliceStationAdd { get; set; }
    }
}
