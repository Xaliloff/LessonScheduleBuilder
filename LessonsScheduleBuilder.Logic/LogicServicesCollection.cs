using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonsScheduleBuilder.Logic.BusinessControllers.Reports;
using AutoMapper;
using LessonsScheduleBuilder.Logic.BusinessControllers.Schedule;

namespace LessonsScheduleBuilder.Logic
{
    public class LogicServicesCollection
    {
        public static void Register (IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IReportBusinessController, ReportBusinessController>();
            services.AddScoped<IScheduleBusinessController, ScheduleBusinessController>();
        }
    }
}
