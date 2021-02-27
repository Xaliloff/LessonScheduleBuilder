using LessonsScheduleBuilder.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.Logic.BusinessControllers.Schedule
{
    public interface IScheduleBusinessController
    {
        Task<IEnumerable<ScheduleLessonDto>> Get(int groupId);
        Task<ResponseDto<ScheduleLessonDto>> Update(ScheduleLessonDto dto);
        Task<ResponseDto<ScheduleLessonDto>> Add(ScheduleLessonDto dto);
    }
}
