using LessonsScheduleBuilder.Data;
using LessonsScheduleBuilder.Data.Enums;
using LessonsScheduleBuilder.Data.Models;
using LessonsScheduleBuilder.Logic.BusinessControllers.Schedule.Validations;
using LessonsScheduleBuilder.Logic.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LessonsScheduleBuilder.UnitTests
{
    public class TestScheduleBuilder
    {
        private readonly DbContextOptions<AppDbContext> options;

        public TestScheduleBuilder()
        {
            options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "inMemoryDB")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new AppDbContext(options))
            {
                //teacher 1 with group 1 
                context.ScheduleLessons.Add(new ScheduleLesson
                {
                    Id = 1,
                    StartTime = new TimeSpan(12, 00, 00),
                    LessonTime = new TimeSpan(0, 45, 0),
                    DayOfTheWeek = DayOfTheWeek.Monday,
                    GroupId = 1,
                    SelectedTeacherId = 1
                });
                context.ScheduleLessons.Add(new ScheduleLesson
                {
                    Id = 2,
                    StartTime = new TimeSpan(13, 20, 00),
                    LessonTime = new TimeSpan(0, 45, 0),
                    DayOfTheWeek = DayOfTheWeek.Monday,
                    GroupId = 1,
                    SelectedTeacherId = 1
                });

                //teacher 1 with group 2
                context.ScheduleLessons.Add(new ScheduleLesson
                {
                    Id = 3,
                    StartTime = new TimeSpan(16, 20, 00),
                    LessonTime = new TimeSpan(0, 45, 0),
                    DayOfTheWeek = DayOfTheWeek.Monday,
                    GroupId = 2,
                    SelectedTeacherId = 1
                });
                context.ScheduleLessons.Add(new ScheduleLesson
                {
                    Id = 4,
                    StartTime = new TimeSpan(17, 20, 00),
                    LessonTime = new TimeSpan(0, 45, 0),
                    DayOfTheWeek = DayOfTheWeek.Monday,
                    GroupId = 2,
                    SelectedTeacherId = 1
                });
                context.SaveChanges();

                //teacher 2 with group 1
                context.ScheduleLessons.Add(new ScheduleLesson
                {
                    Id = 5,
                    StartTime = new TimeSpan(09, 20, 00),
                    LessonTime = new TimeSpan(0, 45, 0),
                    DayOfTheWeek = DayOfTheWeek.Monday,
                    GroupId = 1,
                    SelectedTeacherId = 2
                });
                context.SaveChanges();
            }
        }

        [Theory]
        [InlineData("11:00:00", "00:45:00", 0)]
        [InlineData("09:00:00", "00:45:00", 1)]
        [InlineData("11:50:00", "00:45:00", 2)]
        [InlineData("12:50:00", "00:45:00", 2)]
        public async Task TestOverlapingValidationForGroupOnAddingNewLesson(string startTime, string lessonLength, int numberOfErrors)
        {
            //Arrange
            List<ErrorModel> errors = new List<ErrorModel>();
            var lessonToAdd = new ScheduleLesson()
            {
                Id = 6,
                DayOfTheWeek = DayOfTheWeek.Monday,
                GroupId = 1,
                SelectedTeacherId = 1,
                LessonTypeId = 1,
                StartTime = TimeSpan.Parse(startTime),
                LessonTime = TimeSpan.Parse(lessonLength),
            };

            //Act
            using (var context = new AppDbContext(options))
            {
                var validator = new ScheduledLessonValidation(context);
                errors = await validator.ValidateAsync(lessonToAdd);
                context.Database.EnsureDeleted();
            }

            // Assert
            Assert.Equal(errors.Count(), numberOfErrors);
        }

        [Theory]
        [InlineData("11:00:00", "00:45:00", 0)]
        [InlineData("18:20:00", "00:45:00", 0)]
        [InlineData("11:50:00", "00:45:00", 2)]
        [InlineData("12:10:00", "00:45:00", 2)]
        [InlineData("15:50:00", "00:45:00", 1)]
        public async Task TestOverlapingValidationForTeacherOnAddingNewLesson(string startTime, string lessonLength, int numberOfErrors)
        {
            //Arrange
            List<ErrorModel> errors = new List<ErrorModel>();
            var lessonToAdd = new ScheduleLesson()
            {
                Id = 6,
                DayOfTheWeek = DayOfTheWeek.Monday,
                GroupId = 1,
                SelectedTeacherId = 1,
                LessonTypeId = 1,
                StartTime = TimeSpan.Parse(startTime),
                LessonTime = TimeSpan.Parse(lessonLength),
            };

            //Act
            using (var context = new AppDbContext(options))
            {
                var validator = new ScheduledLessonValidation(context);
                errors = await validator.ValidateAsync(lessonToAdd);
                context.Database.EnsureDeleted();
            }

            // Assert
            Assert.Equal(errors.Count(), numberOfErrors);
        }
    }
}