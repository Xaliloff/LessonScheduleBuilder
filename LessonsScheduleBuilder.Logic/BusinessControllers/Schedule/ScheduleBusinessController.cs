using AutoMapper;
using AutoMapper.QueryableExtensions;
using LessonsScheduleBuilder.Data;
using LessonsScheduleBuilder.Data.Models;
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

        public ScheduleBusinessController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            //check if there is lesson at the same time for selected teacher
            //check if there is lesson at the same time for selected group


            await _dbContext.ScheduleLessons.AddAsync(scheduleLesson);
            await _dbContext.SaveChangesAsync();

            return new ResponseDto<ScheduleLessonDto>(_mapper.Map<ScheduleLessonDto>(scheduleLesson));
        }

        public async Task<ResponseDto<ScheduleLessonDto>> Update(ScheduleLessonDto dto)
        {
            //check if there is lesson at the same time for selected teacher
            //check if there is lesson at the same time for selected group
            var scheduleLessonInDb = await _dbContext.ScheduleLessons.FirstAsync(x => x.Id == dto.Id);

            scheduleLessonInDb.StartTime = dto.StartTime;
            scheduleLessonInDb.DayOfTheWeek = dto.DayOfTheWeek;
            scheduleLessonInDb.SelectedTeacherId = dto.SelectedTeacherId;

            _dbContext.ScheduleLessons.Update(scheduleLessonInDb);
            await _dbContext.SaveChangesAsync();

            return new ResponseDto<ScheduleLessonDto>(_mapper.Map<ScheduleLessonDto>(scheduleLessonInDb));
        }
    }
}