using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
 [Table("MaritalStatus")]
    public class MaritalStatus 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
