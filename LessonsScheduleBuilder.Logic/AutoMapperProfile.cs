using AutoMapper;
using LessonsScheduleBuilder.Data.Models;
using LessonsScheduleBuilder.Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.Logic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ScheduleLesson, ScheduleLessonDto>().ReverseMap();
        }
    }
}
