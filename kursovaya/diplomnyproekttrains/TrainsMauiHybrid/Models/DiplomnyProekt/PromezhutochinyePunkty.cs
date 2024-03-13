using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainsMauiHybrid.Models
{
    [Table("Promezhutochinye_Punkty", Schema = "dbo")]
    public partial class PromezhutochinyePunkty
    {
        [Key]
        [Required]
        public long PunktKey { get; set; }

        public string PunktPoint1 { get; set; }

        public string PunktPoint2 { get; set; }

        public string PunktPoint3 { get; set; }

        public string PunktPoint4 { get; set; }

        public string PunktPoint5 { get; set; }

        public string PunktPoint6 { get; set; }

        public string PunktPoint7 { get; set; }

        public string PunktPoint8 { get; set; }

        public string PunktPoint9 { get; set; }

        public string PunktPoint10 { get; set; }

        public ICollection<Marshuti> Marshutis { get; set; }

    }
}