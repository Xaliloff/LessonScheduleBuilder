using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonsScheduleBuilder.Data.DTOs;
using LessonsScheduleBuilder.Data.Repositories.Interfaces;

namespace LessonsScheduleBuilder.Logic.BusinessControllers.Reports
{
    public class ReportBusinessController : IReportBusinessController
    {
        private readonly ITeacherReportRepository _teacherReportRepository;

        public ReportBusinessController(ITeacherReportRepository teacherReportRepository)
        {
            _teacherReportRepository = teacherReportRepository;
        }
        public async Task<TeacherReportDto> GetTeacherReport()
        {
            return await _teacherReportRepository.Get();
        }
    }
}
