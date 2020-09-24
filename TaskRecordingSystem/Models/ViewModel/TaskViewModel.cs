//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace TaskRecordingSystem.Models.ViewModel
//{
//    public class TaskViewModel
//    {
//        [Key]
//        public int Id { get; set; }

//        [Display(Name = "Task Name")]
//        [Required]
//        public string TaskName { get; set; }
//        public string Description { get; set; }

//        [Display(Name ="Project Name")]
//        [Required]
//        public string ProjectName { get; set; }

//        [Required]
//        [Display(Name ="Add Employee")]
//        public string AddEmployee { get; set; }

//        [Display(Name ="Start Date")]
//        [DataType(DataType.Date)]
//        [Required]
//        public DateTime StartDate { get; set; }

//        [Display(Name = "End Date")]
//        [DataType(DataType.Date)]
//        [Required]
//        public DateTime EndDate { get; set; }
//        public string Status { get; set; }



//    }
//}
