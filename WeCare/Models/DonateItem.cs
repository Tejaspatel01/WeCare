namespace WeCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonateItem")]
    public partial class DonateItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "What Item Do you want to donate: ")]
        public string DonatedItem { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mode of Delivery")]
        public string ModeOfDelivery { get; set; }
    }
}
