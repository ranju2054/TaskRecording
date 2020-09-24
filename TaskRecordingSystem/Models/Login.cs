using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    [Table("Login")]
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
