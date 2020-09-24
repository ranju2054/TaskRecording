using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models.ViewModel
{
    public class ProjectView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Project Name")]
        public string  ProjectName { get; set; }
        public string Description { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        [Display(Name ="Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="End Date")]
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        [Required]
        [Display(Name ="Add Employee")]
        public string AddEmployee { get; set; }

    }
}
