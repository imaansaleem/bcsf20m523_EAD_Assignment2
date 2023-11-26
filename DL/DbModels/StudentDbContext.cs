using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class StudentDbContext : DbContext
    {
        public DbSet <StudentDbDto> Students { get; set; }
        public DbSet<StudentSubjectDbDto> StudentSubjects { get; set; }
        public DbSet<SubjectDbDto> Subjects { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDbDto>().HasKey(e => e.Id);
            modelBuilder.Entity<SubjectDbDto>().HasKey(s => s.Id);
            modelBuilder.Entity<StudentSubjectDbDto>().HasKey(sc => sc.Id);

            modelBuilder.Entity<StudentSubjectDbDto>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentSubjectDbDto>()
                .HasOne(sc => sc.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(sc => sc.SubjectId);
        }

    }
}
