using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_information.Models
{
    public class Fees
    {
        [Key]
        public int FeeId { get; set; }
        [Required]
        public int Amount { get; set; }

        public List<Student> Students { get; set; }
    }
}
