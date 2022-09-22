using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Magnifinance.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Magnifinance.Data
{
    public class MagnifinanceContext : IdentityDbContext<StoreUser>
    {

        private readonly IConfiguration _config;

        public MagnifinanceContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
       
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectGrade> SubjectGrades { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        {
            base.OnConfiguring(bldr);

            bldr.UseSqlServer(_config.GetConnectionString("DutchConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .HasData(new Course
                {
                    CourseId = 1,
                    CourseName = "Introduction To Web Development",
                    Title = "Introduction To Web Development"
                });
            modelBuilder.Entity<Course>()
                .HasData(new Course
                {
                    CourseId = 2,
                    CourseName = "Advance Web Development",
                    Title = "Advance To Web Development"
                });

            modelBuilder.Entity<Teacher>()
    .HasData(new Teacher
    {
        TeacherId = 1,
        FirstName = "Marie",
        LastName = "Lina",
        Age = 30,
        IsActive = true,
    });

            modelBuilder.Entity<Teacher>()
                .HasData(new Teacher
                {
                    TeacherId = 2,
                    FirstName = "Rihan",
                    LastName = "Munabih",
                    Age = 28,
                    IsActive = true,
                });

            modelBuilder.Entity<Teacher>()
                .HasData(new Teacher
                {
                    TeacherId = 3,
                    FirstName = "Jhon",
                    LastName = "Baker",
                    Age = 29,
                    IsActive = true,
                });

            modelBuilder.Entity<Teacher>()
                .HasData(new Teacher
                {
                    TeacherId = 4,
                    FirstName = "Mark",
                    LastName = "Jacobs",
                    Age = 29,
                    IsActive = true,
                });
            modelBuilder.Entity<Teacher>()
                .HasData(new Teacher
                {
                    TeacherId = 5,
                    FirstName = "Ahmed",
                    LastName = "Zamil",
                    Age = 35,
                    IsActive = true,
                });

            modelBuilder.Entity<Subject>()
                .HasData(new Subject
                {
                    SubjectId = 1,
                    SubjectName = "JAVA",
                    SubjectTitle = "JAVA",
                    IsMajor = true,
                    CourseId = 2,
                    TeacherId = 1,
                });
            modelBuilder.Entity<Subject>()
                .HasData(new Subject
                {
                    SubjectId = 2,
                    SubjectName = "ASP.NET",
                    SubjectTitle = "ASP.NET",
                    IsMajor = true,
                    CourseId = 2,
                    TeacherId = 2,
                });

            modelBuilder.Entity<Subject>()
                .HasData(new Subject
                {
                    SubjectId = 3,
                    SubjectName = "ANGULAR",
                    SubjectTitle = "ANGULAR",
                    IsMajor = true,
                    CourseId = 2,
                    TeacherId = 3,
                });

            modelBuilder.Entity<Subject>()
                .HasData(new Subject
                {
                    SubjectId = 4,
                    SubjectName = "OOP Concepts",
                    SubjectTitle = "OOP Concepts",
                    IsMajor = true,
                    CourseId = 1,
                    TeacherId = 4,
                });

            modelBuilder.Entity<Subject>()
                .HasData(new Subject
                {
                    SubjectId = 5,
                    SubjectName = "Programming Fundamentals ",
                    SubjectTitle = "Programming Fundamentals ",
                    IsMajor = true,
                    CourseId = 1,
                    TeacherId = 5,
                });

            modelBuilder.Entity<Subject>()
                .HasData(new Subject
                {
                    SubjectId = 6,
                    SubjectName = "C Programming",
                    SubjectTitle = "C Programming",
                    IsMajor = true,
                    CourseId = 1,
                    TeacherId = 1,
                });






            modelBuilder.Entity<Student>()
                .HasData(new Student
                {
                    StudentId = 1,
                    FirstName = "Sakib Hasan",
                    LastName = "Hasan",
                    Age = 20
                });

            modelBuilder.Entity<Student>()
                .HasData(new Student
                {
                    StudentId = 2,
                    FirstName = "Liton",
                    LastName = "Das",
                    Age = 22
                });

            modelBuilder.Entity<Student>()
                .HasData(new Student
                {
                    StudentId = 3,
                    FirstName = "Taskin",
                    LastName = "Ahmed",
                    Age = 25
                });


            modelBuilder.Entity<StudentCourse>()
    .HasData(new StudentCourse
    {
        StudentCourseId = 1,
        Note = "Fruit pies",

        StudentId = 1,
        CourseId = 2
    });

            modelBuilder.Entity<StudentCourse>()
                .HasData(new StudentCourse
                {
                    StudentCourseId = 2,
                    Note = "Student 2 takes course 2",

                    StudentId = 2,
                    CourseId = 2
                });

            modelBuilder.Entity<StudentCourse>()
                .HasData(new StudentCourse
                {
                    StudentCourseId = 3,
                    Note = "Student 3 takes course 3",

                    StudentId = 3,
                    CourseId = 1
                });


            //modelBuilder.Entity<Grade>()
            //    .HasData(new Grade
            //    {
            //        GradeId = 1,
            //        GradeInitial = "A+",
            //        Point = 4.0,
            //        Comments = "Full"
            //    });

            //modelBuilder.Entity<Grade>()
            //    .HasData(new Grade
            //    {
            //        GradeId = 2,
            //        GradeInitial = "B+",
            //        Point = 3.5,
            //        Comments = "Bright"
            //    });
            //modelBuilder.Entity<Grade>()
            //    .HasData(new Grade
            //    {
            //        GradeId = 3,
            //        GradeInitial = "C",
            //        Point = 3.0,
            //        Comments = "Pass"
            //    });

            modelBuilder.Entity<SubjectGrade>()
                .HasData(new SubjectGrade
                {
                    SubjectGradeId = 1,
                    StudentId = 1,
                    Grade = "A+",
                    GradePoint = 4.0,
                    SubjectId = 1
                });

            modelBuilder.Entity<SubjectGrade>()
                .HasData(new SubjectGrade
                {
                    SubjectGradeId = 2,
                    StudentId = 1,
                    Grade = "A+",
                    GradePoint = 4.0,
                    SubjectId = 2
                });

            modelBuilder.Entity<SubjectGrade>()
                .HasData(new SubjectGrade
                {
                    SubjectGradeId = 3,
                    StudentId = 1,
                    Grade = "A+",
                    GradePoint = 4.0,
                    SubjectId = 3
                });

            modelBuilder.Entity<SubjectGrade>()
                .HasData(new SubjectGrade
                {
                    SubjectGradeId = 4,
                    StudentId = 2,
                    Grade = "A+",
                    GradePoint = 4.0,
                    SubjectId = 1
                });
            modelBuilder.Entity<SubjectGrade>()
                 .HasData(new SubjectGrade
                 {
                     SubjectGradeId = 5,
                     StudentId = 2,
                     Grade = "A+",
                     GradePoint = 4.0,
                     SubjectId = 2
                 });
            modelBuilder.Entity<SubjectGrade>()
                 .HasData(new SubjectGrade
                 {
                     SubjectGradeId = 6,
                     StudentId = 2,
                     Grade = "A+",
                     GradePoint = 4.0,
                     SubjectId = 3
                 });

            modelBuilder.Entity<SubjectGrade>()
                 .HasData(new SubjectGrade
                 {
                     SubjectGradeId = 7,
                     StudentId = 3,
                     Grade = "A+",
                     GradePoint = 4.0,
                     SubjectId = 4
                 });
            modelBuilder.Entity<SubjectGrade>()
                 .HasData(new SubjectGrade
                 {
                     SubjectGradeId = 8,
                     StudentId = 3,
                     Grade = "A+",
                     GradePoint = 4.0,
                     SubjectId = 5
                 });
            modelBuilder.Entity<SubjectGrade>()
                 .HasData(new SubjectGrade
                 {
                     SubjectGradeId = 9,
                     StudentId = 3,
                     Grade = "A+",
                     GradePoint = 4.0,
                     SubjectId = 6
                 });
            //    CourseId
            //    CourseName
            // Title

            //List<StudentCourse> StudentCourses

            //List<Subject> Subjects

        }
    }
}
