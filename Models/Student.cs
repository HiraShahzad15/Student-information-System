using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student_information.Models
{
    public class Student
    {
        [Key]
        public int StdId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string address { get; set; }
        [Required]

        public int DOB { get; set; }

        [ForeignKey("Subject")]
        public int SubId { get; set; }
        public virtual Subject Subjects { get; set; }
        //public List<Fees> Fees { get; set; }
        public int FeeId { get; set; }
        public virtual Fees Fees { get; set; }

    }
}
