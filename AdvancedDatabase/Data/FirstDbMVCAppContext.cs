using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstDbMVCApp.Models;

namespace FirstDbMVCApp.Data
{
    public class FirstDbMVCAppContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.EnrolledStudents)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Other model configurations
        }

        public FirstDbMVCAppContext (DbContextOptions<FirstDbMVCAppContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;
    }
}
