using LessonsScheduleBuilder.Data.Models;
using LessonsScheduleBuilder.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.Logic.BusinessControllers.Schedule.Validations
{
    public interface IScheduledLessonValidation
    {
        Task<List<ErrorModel>> ValidateAsync(ScheduleLesson lessonToSet);
    }
}
