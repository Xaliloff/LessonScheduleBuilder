using LessonsScheduleBuilder.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsScheduleBuilder.Data.Models
{
    public class ScheduleLesson
    {
        public int Id { get; set; }
        public DayOfTheWeek DayOfTheWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan LessonTime { get; set; }
        public int LessonTypeId { get; set; }
        public LessonType LessonType { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int SelectedTeacherId { get; set; }
        public Teacher SelectedTeacher { get; set; }
    }
}
