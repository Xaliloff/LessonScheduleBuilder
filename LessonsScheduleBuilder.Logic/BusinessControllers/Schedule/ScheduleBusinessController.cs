using AutoMapper;
using AutoMapper.QueryableExtensions;
using LessonsScheduleBuilder.Data;
using LessonsScheduleBuilder.Data.Models;
using LessonsScheduleBuilder.Logic.BusinessControllers.Schedule.Validations;
using LessonsScheduleBuilder.Logic.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.Logic.BusinessControllers.Schedule
{
    public class ScheduleBusinessController : IScheduleBusinessController
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IScheduledLessonValidation _scheduleValidation;

        public ScheduleBusinessController(AppDbContext dbContext, IMapper mapper, IScheduledLessonValidation scheduleValidation)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _scheduleValidation = scheduleValidation;
        }

        public async Task<IEnumerable<ScheduleLessonDto>> Get(int groupId)
        {
            return await _dbContext.ScheduleLessons.
                AsNoTracking().
                Where(x => x.GroupId == groupId).
                Select(x => new ScheduleLessonDto()
                {
                    Id = x.Id,
                    GroupId = x.GroupId,
                    GroupName = x.Group.GroupName,
                    LessonTime = x.LessonTime,
                    LessonTypeId = x.LessonTypeId,
                    LessonTypeName = x.LessonType.Name,
                    SelectedTeacherId = x.SelectedTeacherId,
                    SelectedTeacherName = x.SelectedTeacher.FirstName + x.SelectedTeacher.LastName,
                    StartTime = x.StartTime
                }).
                ToListAsync();
        }

        public async Task<ResponseDto<ScheduleLessonDto>> Add(ScheduleLessonDto dto)
        {
            var scheduleLesson = _mapper.Map<ScheduleLesson>(dto);

            var errors = await _scheduleValidation.ValidateAsync(scheduleLesson);
            if (errors.Any()) return new ResponseDto<ScheduleLessonDto>(errors);
            

            await _dbContext.ScheduleLessons.AddAsync(scheduleLesson);
            await _dbContext.SaveChangesAsync();

            return new ResponseDto<ScheduleLessonDto>(_mapper.Map<ScheduleLessonDto>(scheduleLesson));
        }

        public async Task<ResponseDto<ScheduleLessonDto>> Update(ScheduleLessonDto dto)
        {
            var scheduleLessonInDb = await _dbContext.ScheduleLessons.FirstAsync(x => x.Id == dto.Id);

            scheduleLessonInDb.StartTime = dto.StartTime;
            scheduleLessonInDb.DayOfTheWeek = dto.DayOfTheWeek;
            scheduleLessonInDb.SelectedTeacherId = dto.SelectedTeacherId;

            var errors = await _scheduleValidation.ValidateAsync(scheduleLessonInDb);
            if (errors.Any()) return new ResponseDto<ScheduleLessonDto>(errors);

            _dbContext.ScheduleLessons.Update(scheduleLessonInDb);
            await _dbContext.SaveChangesAsync();

            return new ResponseDto<ScheduleLessonDto>(_mapper.Map<ScheduleLessonDto>(scheduleLessonInDb));
        }
    }
}