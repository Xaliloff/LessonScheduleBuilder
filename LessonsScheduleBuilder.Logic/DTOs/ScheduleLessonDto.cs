using LessonsScheduleBuilder.Data.Enums;
using System;

namespace LessonsScheduleBuilder.Logic.DTOs
{
    public class ScheduleLessonDto
    {
        public int Id { get; set; }
        public DayOfTheWeek DayOfTheWeek { get;set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan LessonTime { get; set; }
        public int LessonTypeId { get; set; }
        public string LessonTypeName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int SelectedTeacherId { get; set; }
        public string SelectedTeacherName { get; set; }
    }
}