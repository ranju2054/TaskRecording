using Microsoft.AspNetCore.Identity;
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

        [Display(Name ="Project Name")]
        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }

        [Display(Name = "Department Name")]
        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name ="End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name ="Status")]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

       



    }
}
