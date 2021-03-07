using System.Collections.Generic;

namespace LessonsScheduleBuilder.Data.Models
{
    public class Group
    {
        public int Id { get; set; }
        public short Grade { get; set; }
        public string GroupSuffix { get; set; }
        public string Field2 { get; set; }
        public string GroupName
        {
            get
            {
                return Grade + GroupSuffix;
            }
        }

        public List<Student> Students { get; set; }
        public List<ScheduleLesson> ScheduleLessons { get; set; }
        public Group()
        {
            Students = new List<Student>();
            ScheduleLessons = new List<ScheduleLesson>();
        }
    }
}