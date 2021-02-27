using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsScheduleBuilder.Data.Models
{
    public class Student : User
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
