using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TaskName { get; set; }
        public string Description { get; set; }

        [Required]
        [Display(Name ="Project Name")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
     
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public string Priority { get; set; }
    }
}
