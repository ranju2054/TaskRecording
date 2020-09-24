using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models.ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Display(Name ="User Name")]
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
