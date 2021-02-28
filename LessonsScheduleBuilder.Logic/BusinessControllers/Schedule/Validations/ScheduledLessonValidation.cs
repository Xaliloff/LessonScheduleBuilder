using LessonsScheduleBuilder.Data;
using LessonsScheduleBuilder.Data.Models;
using LessonsScheduleBuilder.Logic.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.Logic.BusinessControllers.Schedule.Validations
{
    public class ScheduledLessonValidation : IScheduledLessonValidation
    {
        private readonly AppDbContext _context;
        private readonly ScheduleFluentValidation _fluentValidation;

        public ScheduledLessonValidation(AppDbContext context)
        {
            _context = context;
            _fluentValidation = new ScheduleFluentValidation();
        }

        public async Task<List<ErrorModel>> ValidateAsync(ScheduleLesson lessonToSet)
        {
            var errors = new List<ErrorModel>();

            var result = _fluentValidation.Validate(lessonToSet);
            if (!result.IsValid)
            {
                return new List<ErrorModel>(result.Errors.Select(x => new ErrorModel(x.ErrorMessage)));
            }

            //get lessons for that day of the week for both teacher and group
            var lessonsInThatDay = await _context.ScheduleLessons.
                                    Where(x => x.DayOfTheWeek == lessonToSet.DayOfTheWeek &&
                                              (x.SelectedTeacherId == lessonToSet.SelectedTeacherId || x.GroupId == lessonToSet.GroupId)).ToListAsync();

            //except itself
            lessonsInThatDay = lessonsInThatDay.Where(x => x.Id != lessonToSet.Id).ToList();

            //check lesson time overlaps with students lessons
            if(lessonsInThatDay.
                Where(x => x.GroupId == lessonToSet.GroupId).
                Any(x => x.StartTime < lessonToSet.EndTime && lessonToSet.StartTime < x.EndTime))
            {
                errors.Add(new ErrorModel("This group already has lesson in selected time. Please check schedule."));
            }

            //check lesson time overlaps with teacher's lessons
            if (lessonsInThatDay.
                Where(x => x.SelectedTeacherId == lessonToSet.SelectedTeacherId).
                Any(x => x.StartTime < lessonToSet.EndTime && lessonToSet.StartTime < x.EndTime))
            {
                errors.Add(new ErrorModel("This teacher already has lesson in selected time. Please check schedule."));
            }

            return errors;
        }
    }
}