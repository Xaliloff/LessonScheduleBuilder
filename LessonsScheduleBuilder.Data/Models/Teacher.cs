using System.Collections.Generic;

namespace LessonsScheduleBuilder.Data.Models
{
    public class Teacher : User
    {
        public List<TeacherSpecialization> Specializations { get; set; }
        public Teacher()
        {
            Specializations = new List<TeacherSpecialization>();
        }
    }
}