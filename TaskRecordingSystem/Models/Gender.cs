using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("Gender")]
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string GenderStatus { get; set; }
    }
}
