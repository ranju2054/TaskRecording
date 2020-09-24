using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("JobPosition")]
    public class JobPosition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Position { get; set; }
      
        public string Grade { get; set; }

        [Required]
        public string Level { get; set; }
    }
}
