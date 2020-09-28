using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("EmployeeTask")]
    public class EmployeeTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Task Name")]
        public string TaskName { get; set; }
        public string Description { get; set; }

        [Required]
        [Display(Name ="Project Name")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
     
        [Required]
       
        [Display(Name ="Start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name ="End Date")]
        public DateTime EndDate { get; set; }
        public int PriorityId { get; set; }

        [ForeignKey("PriorityId")]
        [Display(Name = "Priority")]
        public virtual Priority Priority{ get; set; }

        [Display(Name = "Add Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual ICollection<Employee> Employees { get; set; }




    }
}
