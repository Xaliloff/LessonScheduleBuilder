using LessonsScheduleBuilder.Logic.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.API.Controllers
{
    public class ApplicationController : ControllerBase
    {
        public ApplicationController()
        {
        }

        protected ActionResult HandleResponse<T>(ResponseDto<T> responseDto)
        {
            if (!responseDto.HasError)
            {
                return Ok(responseDto.Body);
            }
            else
            {
                return BadRequest(responseDto.Errors);
            }
        }
    }
}
