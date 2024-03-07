using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrainsMauiHybrid.Models
{
    [Table("Marshuti", Schema = "dbo")]
    public partial class Marshuti
    {
        [Key]
        [Required]
        public long Nomer_Marshuta { get; set; }

        [Required]
        public string Nachalni_Punkt { get; set; }

        [Required]
        public string Mid_Punkt { get; set; }

        [Required]
        public string Konechni_Punkt { get; set; }

        [Required]
        public long Emp_Num { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public long ModelTrainKey { get; set; }

        public Train Train { get; set; }

        [Required]
        public string Vremya_Proezda { get; set; }

        public ICollection<Bilety> Bileties { get; set; }

    }
}