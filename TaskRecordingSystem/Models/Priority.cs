using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("Priority")]
    public class Priority
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        [Display(Name ="Priority")]
        public string PriorityStatus { get; set; }
    }
}
