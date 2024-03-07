using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrainsMauiHybrid.Models
{
    [Table("Prodazhi", Schema = "dbo")]
    public partial class Prodazhi
    {
        [Key]
        [Required]
        public long Num { get; set; }

        [Required]
        public string Sale_Date { get; set; }

        public long? Nomer_BiletaKey { get; set; }

        public Bilety Bilety { get; set; }

    }
}