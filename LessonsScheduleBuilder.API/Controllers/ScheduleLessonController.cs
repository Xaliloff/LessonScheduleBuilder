using LessonsScheduleBuilder.Logic.BusinessControllers.Schedule;
using LessonsScheduleBuilder.Logic.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.API.Controllers
{
    [Route("scheduleLesson")]
    [ApiController]
    public class ScheduleLessonController : ApplicationController
    {
        private readonly IScheduleBusinessController _scheduleBusinessController;

        public ScheduleLessonController(IScheduleBusinessController scheduleBusinessController)
        {
            _scheduleBusinessController = scheduleBusinessController;
        }

        [HttpGet("{groupId}")]
        [Produces(typeof(List<ScheduleLessonDto>))]
        public async Task<IActionResult> GetForGroup(int groupId)
        {
            return Ok(await _scheduleBusinessController.Get(groupId));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ScheduleLessonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateScheduleLesson(ScheduleLessonDto dto)
        {
            return HandleResponse(await _scheduleBusinessController.Update(dto));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ScheduleLessonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ErrorModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddScheduleLesson(ScheduleLessonDto dto)
        {
            return HandleResponse(await _scheduleBusinessController.Add(dto));
        }
    }
}
