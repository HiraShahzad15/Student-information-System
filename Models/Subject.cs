using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_information.Models
{
    public class Subject
    {
        [Key]
        public int SubId { get; set; }
        [Required]
        public string name { get; set; }
        public List<Student> Students { get; set; }

    }
}
