using LessonsScheduleBuilder.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.Data.ModelsConfiguration
{
    class ScheduleLessonEFConfig : IEntityTypeConfiguration<ScheduleLesson>
    {
        public void Configure(EntityTypeBuilder<ScheduleLesson> builder)
        {
            builder.HasOne(x => x.Group).WithMany(x => x.ScheduleLessons).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
