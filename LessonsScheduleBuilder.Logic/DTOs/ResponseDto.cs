using System.Collections.Generic;
using System.Linq;

namespace LessonsScheduleBuilder.Logic.DTOs
{
    public class ResponseDto<T>
    {
        public T Body { get; set; }
        public List<ErrorModel> Errors { get; set; }
        public bool HasError
        {
            get
            {
                return Errors.Any();
            }
        }

        public ResponseDto(T body)
        {
            Body = body;
            Errors = new List<ErrorModel>();
        }

        public ResponseDto(List<ErrorModel> errors)
        {
            Errors = errors;
        }

        public ResponseDto(ErrorModel error)
        {
            Errors = new List<ErrorModel>() { error };
        }

        public ResponseDto(string errorText)
        {
            Errors = new List<ErrorModel>() { new ErrorModel(0, errorText) };
        }
    }

    public class ErrorModel
    {
        public ErrorModel(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; }
        public string Message { get; }
    }
}