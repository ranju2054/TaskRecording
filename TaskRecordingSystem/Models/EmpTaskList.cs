using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRecordingSystem.Models
{
    public class EmpTaskList
    {
        public int Id { get; set; }
        public  int UserId  { get; set; }

        [ForeignKey("UseriD")]
        public virtual User User { get; set; }
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual Task Task { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}
