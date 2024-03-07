using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrainsMauiHybrid.Models
{
    [Table("Obsluzhivanie", Schema = "dbo")]
    public partial class Obsluzhivanie
    {
        [Key]
        [Required]
        public long NomerObsluzhivania { get; set; }

        public long? Model_TrainKey { get; set; }

        public Train Train { get; set; }

        public string Data_Poslednego_Obsluzhivania { get; set; }

        public string Ingener_Obsluzhivania { get; set; }

        public string Problemi_Sostava { get; set; }

        public string Data_Sledueschego_Obsluzivania { get; set; }

        public string Goden_K_Doroge { get; set; }

    }
}