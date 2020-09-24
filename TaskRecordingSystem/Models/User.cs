using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [EmailAddress]
        [Required(ErrorMessage ="Email Address Required.")]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }
       
        [Required]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
       public virtual Address Address { get; set; }
        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }
        
        [Required(ErrorMessage ="Date Of Birth required.")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime DateOfJoin { get; set; }
        public int MaritalStatusId { get; set; }

        [ForeignKey("MaritalStatusId")]
        public virtual MaritalStatus MaritalStatus { get; set; }

        [Required]
        public int UserRoleId { get; set; }

        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRole { get; set; }

        [Display(Name ="Department Name")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public int JobPositionId { get; set; }

        [ForeignKey("JobPositionId")]
        public virtual JobPosition JobPosition { get; set; }

       
        
       


    }
}
