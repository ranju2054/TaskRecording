using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Permanent District")]
        public string  PermanentDistrict { get; set; }

        [Display(Name ="Temporary District")]
        [Required]
        public string TemporaryDistrict { get; set; }
        [Required]
        public string Place { get; set; }

        [Required]
        [Display(Name ="Phone Number")]
        public string ContactNumber { get; set; }

       
    }
}
