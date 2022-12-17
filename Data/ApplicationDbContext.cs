using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Student_information.Models;

namespace Student_information.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student_information.Models.Student> Student { get; set; }
        public DbSet<Student_information.Models.Subject> Subject { get; set; }
        public DbSet<Student_information.Models.StdSubject> StdSubject { get; set; }
        public DbSet<Student_information.Models.Fees> Fees { get; set; }
    }
}
