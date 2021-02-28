using FluentValidation;
using LessonsScheduleBuilder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.Logic.BusinessControllers.Schedule.Validations
{
    public class ScheduleFluentValidation : AbstractValidator<ScheduleLesson>
    {
        public ScheduleFluentValidation()
        {
            RuleFor(lesson => lesson.StartTime).NotEmpty();
            RuleFor(lesson => lesson.LessonTime).NotEmpty();
            RuleFor(lesson => lesson.LessonTypeId).NotEmpty();
            RuleFor(lesson => lesson.SelectedTeacherId).NotEmpty();
            RuleFor(lesson => lesson.GroupId).NotEmpty();
            RuleFor(lesson => lesson.LessonTime).NotEmpty();
        }
    }
}
