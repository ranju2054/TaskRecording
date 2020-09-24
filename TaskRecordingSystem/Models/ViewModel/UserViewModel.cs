//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TaskRecordingSystem.Models.ViewModel
//{
//    public class UserViewModel
//    {
//        [Key]
//        public int Id { get; set; }

//        [Display(Name = "User Name")]
//       public string UserName  { get; set; }

//        [DataType(DataType.Password)]
//        [Required]
//        public string Password { get; set; }

//        [Display(Name ="Email Address")]
//        [DataType(DataType.EmailAddress)]

//        [Required]
//        public string EmailAddress { get; set; }
        
//        public string Place { get; set; }

//        [Display(Name ="Marital Status")]
//        public string MaritalStatus { get; set; }

//        [Required]
//        public string Gender { get; set; }

//        [Display(Name ="Date of Birth")]
//        public DateTime DateOfBirth { get; set; }

//        [Display(Name ="Date of Join")]
//        [Required]
//        public DateTime DateOfJoin { get; set; }

//        [Required]
//        public string Role { get; set; }

//        [Required]
//        public string Department  { get; set; }

//        [Required]

//        [Display(Name ="Job Position")]
//        public string JobPosition { get; set; }

//    }
//}
