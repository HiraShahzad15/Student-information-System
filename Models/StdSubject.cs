using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student_information.Models
{
    public class StdSubject
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StdId { get; set; }
        public Student Students { get; set; }
        [ForeignKey("Subject")]
        public int SubId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
