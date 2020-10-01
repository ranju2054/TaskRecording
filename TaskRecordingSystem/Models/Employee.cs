using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Employee Name")]
        [Required]
        public string Name { get; set; }

        //[Display(Name ="Many Employees")]
        //public List<string> ManyName { get; set; }
        [Required]
        [Display(Name ="Current Address")]
        public int AddressId { get; set; }
       
        [ForeignKey("AddressId")]
       public virtual Address Address { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
       
        public virtual Gender Gender { get; set; }
        
        [Required(ErrorMessage ="Date Of Birth required.")]
        [Display(Name ="Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name ="Date of Join")]
        public DateTime DateOfJoin { get; set; }
        [Display(Name ="Marital Status")]
        public int MaritalStatusId { get; set; }

        [ForeignKey("MaritalStatusId")]
        public virtual MaritalStatus MaritalStatus { get; set; }

        [Display(Name ="Department Name")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required]
        [Display(Name = "Job Position")]
        public int JobPositionId { get; set; }

        [ForeignKey("JobPositionId")]
       
        public virtual JobPosition JobPosition { get; set; }
      
    }
}
