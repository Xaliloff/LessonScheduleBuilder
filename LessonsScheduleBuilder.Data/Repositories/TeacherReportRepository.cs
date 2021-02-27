using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonsScheduleBuilder.Data.DTOs;
using LessonsScheduleBuilder.Data.Models;
using LessonsScheduleBuilder.Data.Repositories.Interfaces;

namespace LessonsScheduleBuilder.Data.Repositories
{
    public class TeacherReportRepository : ITeacherReportRepository
    {
        private readonly AppDbContext _context;

        public TeacherReportRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<TeacherReportDto> Get()
        {
            //most busy teacher
            //Teacher with the most count of students
            //Teacher with the most count of groups
            var sql = @"
                select
                (select top 1 
                (select u.Id, u.FirstName, u.LastName, count(*) as ScheduleLessonsNumber 
                from Users u
                left join ScheduleLessons sl left join u.id = sl.SelectedTeacherId
                group by u.Id, u.FirstName, u.LastName) table1 
                order by ScheduleLessonsNumber) as  ,
                ";

            return (await _context.Database.SqlQueryAsync<TeacherReportDto>(sql)).First();
        }
    }
}
