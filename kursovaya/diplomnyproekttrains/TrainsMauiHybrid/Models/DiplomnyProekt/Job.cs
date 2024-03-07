using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrainsMauiHybrid.Models
{
    [Table("Jobs", Schema = "dbo")]
    public partial class Job
    {
        [Key]
        [Required]
        public long Job_Num { get; set; }

        [Column("Job")]
        public string Job1 { get; set; }

        public string Internship { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}