using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
   

    }
}
