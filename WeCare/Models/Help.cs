namespace WeCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Help")]
    public partial class Help
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "What kind of help do you need")]
        public string HelpType { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Address Of User")]
        public string Address { get; set; }
    }
}
