using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrainsMauiHybrid.Models
{
    [Table("Trains", Schema = "dbo")]
    public partial class Train
    {
        [Key]
        [Required]
        public long NumVagona { get; set; }

        public string Model_Sostava_Vagonov { get; set; }

        public long? Kolichestvo_Mest { get; set; }

        public ICollection<Marshuti> Marshutis { get; set; }

        public ICollection<Obsluzhivanie> Obsluzhivanies { get; set; }

    }
}