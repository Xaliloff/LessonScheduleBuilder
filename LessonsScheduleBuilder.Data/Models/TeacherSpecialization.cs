namespace LessonsScheduleBuilder.Data.Models
{
    public class TeacherSpecialization
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int LessonTypeId { get; set; }
        public LessonType LessonType { get; set; }
    }
}