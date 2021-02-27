using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonsScheduleBuilder.Data.DTOs;

namespace LessonsScheduleBuilder.Data.Repositories.Interfaces
{
    public interface ITeacherReportRepository
    {
        Task<TeacherReportDto> Get();
    }
}
