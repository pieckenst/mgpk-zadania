using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrainsMauiHybrid.Models
{
    [Table("Bilety", Schema = "dbo")]
    public partial class Bilety
    {
        [Key]
        [Required]
        public long Nomer_Bileta { get; set; }

        public long? Nomer_MarshutaKey { get; set; }

        public Marshuti Marshuti { get; set; }

        [Required]
        public string Stoimost { get; set; }

        public ICollection<Prodazhi> Prodazhis { get; set; }

    }
}