using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrainsMauiHybrid.Models
{
    [Table("Employees", Schema = "dbo")]
    public partial class Employee
    {
        [Key]
        [Required]
        public long Num { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronym { get; set; }

        public string Employed_Since { get; set; }

        public long? Job_Num { get; set; }

        public Job Job { get; set; }

        public ICollection<Marshuti> Marshutis { get; set; }

    }
}