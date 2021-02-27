using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonsScheduleBuilder.Data.Models;

namespace LessonsScheduleBuilder.Data.ModelsConfiguration
{
    public class LessonTypeEFConfig : IEntityTypeConfiguration<LessonType>
    {
        public void Configure(EntityTypeBuilder<LessonType> builder)
        {
            builder.Property(x => x.Name).HasColumnType("nvarchar(255)");
        }
    }
}
