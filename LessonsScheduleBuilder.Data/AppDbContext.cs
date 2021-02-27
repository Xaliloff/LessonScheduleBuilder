using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using LessonsScheduleBuilder.Data.Models;

namespace LessonsScheduleBuilder.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ScheduleLesson> ScheduleLessons { get; set; }
        public DbSet<TeacherSpecialization> TeacherSpecializations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
