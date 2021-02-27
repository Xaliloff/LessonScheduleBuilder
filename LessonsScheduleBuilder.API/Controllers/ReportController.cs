using LessonsScheduleBuilder.Data;
using LessonsScheduleBuilder.Data.DTOs;
using LessonsScheduleBuilder.Data.Models;
using LessonsScheduleBuilder.Logic.BusinessControllers.Reports;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.API.Controllers
{
    [Route("report")]
    [ApiController]
    public class ReportController : ApplicationController
    {
        private readonly IReportBusinessController _reportBusinessController;
        private readonly AppDbContext context;

        public ReportController(IReportBusinessController reportBusinessController, AppDbContext context)
        {
            _reportBusinessController = reportBusinessController;
            this.context = context;
        }

        [HttpGet]
        [Produces(typeof(TeacherReportDto))]
        public async Task<IActionResult> GetTeacherReport()
        {
            return Ok(await _reportBusinessController.GetTeacherReport());
        }

        //[HttpPost("populateData")]
        //[Produces(typeof(TeacherReportDto))]
        private async Task<IActionResult> PopulateData()
        {
            var groups = new List<Group>() {
                new Group()
                {
                    Grade = 5,
                    GroupSuffix = "a",
                    Students = new List<Student>() {
                    new Student() { FirstName = "Alex", LastName = "Alexov" },
                    new Student() { FirstName = "Kamran", LastName = "Khalilov" },
                    new Student() { FirstName = "Roman", LastName = "Romanovich" },
                    }
                },
                new Group()
                {
                    Grade = 5,
                    GroupSuffix = "b",
                    Students = new List<Student>() {
                    new Student() { FirstName = "Roman", LastName = "Romanovich" },
                    new Student() { FirstName = "Vasiliy", LastName = "Vasilyevich" },
                    new Student() { FirstName = "Sasha", LastName = "Kupcova" },
                    }
                },
                new Group()
                {
                    Grade = 5,
                    GroupSuffix = "b",
                    Students = new List<Student>() {
                    new Student() { FirstName = "Valentina", LastName = "Rudchenko" },
                    new Student() { FirstName = "Valentin", LastName = "Valentinovich" },
                    new Student() { FirstName = "Karamel", LastName = "Karamelevich" },
                    }
                }
            };

            await context.Groups.AddRangeAsync(groups);

            var geography = new LessonType() { Name = "Geography" };
            var math = new LessonType() { Name = "Math" };
            var english = new LessonType() { Name = "English" };
            var art = new LessonType() { Name = "Art" };

            var teacher1 = new Teacher() { FirstName = "Valentina", LastName = "Petrovna"};
            teacher1.Specializations.Add(new TeacherSpecialization() { Teacher = teacher1, LessonType = geography });
            var teacher2 = new Teacher() { FirstName = "Saida", LastName = "Gamidovna" };
            teacher1.Specializations.Add(new TeacherSpecialization() { Teacher = teacher2, LessonType = math });
            var teacher3 = new Teacher() { FirstName = "Nadejda", LastName = "Nikolayevna" };
            teacher1.Specializations.Add(new TeacherSpecialization() { Teacher = teacher3, LessonType = art });


            await context.Teachers.AddRangeAsync(teacher1, teacher2, teacher3);

            await context.SaveChangesAsync();

            return Ok();
        }

        //[HttpGet("studentReport")]
        //[Produces(typeof(TeacherReportDto))]
        //public async Task<IActionResult> GetStudentReport()
        //{
        //    //return Ok(await _reportBusinessController.GetStudentReport());
        //    return Ok();
        //}
    }
}