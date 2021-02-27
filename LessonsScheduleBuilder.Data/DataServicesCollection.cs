using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using LessonsScheduleBuilder.Data.Repositories;
using LessonsScheduleBuilder.Data.Repositories.Interfaces;

namespace LessonsScheduleBuilder.Data
{
    public static class DataServicesCollection
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<ITeacherReportRepository, TeacherReportRepository>();
        }
    }
}
