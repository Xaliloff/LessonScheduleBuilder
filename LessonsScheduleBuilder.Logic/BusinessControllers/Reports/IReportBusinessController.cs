using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonsScheduleBuilder.Data.DTOs;

namespace LessonsScheduleBuilder.Logic.BusinessControllers.Reports
{
    public interface IReportBusinessController
    {
        Task<TeacherReportDto> GetTeacherReport();
    }
}
