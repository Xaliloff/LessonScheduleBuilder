using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonsScheduleBuilder.Logic.BusinessControllers.Reports;
using AutoMapper;
using LessonsScheduleBuilder.Logic.BusinessControllers.Schedule;
using LessonsScheduleBuilder.Logic.BusinessControllers.Schedule.Validations;

namespace LessonsScheduleBuilder.Logic
{
    public static class BusinessServicesCollection
    {
        public static void RegisterBusinessServices (this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IReportBusinessController, ReportBusinessController>();
            services.AddScoped<IScheduleBusinessController, ScheduleBusinessController>();

            services.AddTransient<IScheduledLessonValidation, ScheduledLessonValidation>();
        }
    }
}
