using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace ExpressGlobalExceptionHandler
{
    public interface IResponse
    {

    }

    public class Response<T> : IResponse
    {
        public bool IsSuccess { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public IEnumerable<string> Info { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Response()
        {
            Info = new List<string>();
            ResponseStatus = ResponseStatus.SUCCESS;
            Message = "The request was successfull";
            IsSuccess = true;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Response : IResponse
    {
        public bool IsSuccess { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public IEnumerable<string> Info { get; set; }
        public string Message { get; set; }

        public Response()
        {
            Info = new List<string>();
            ResponseStatus = ResponseStatus.SUCCESS;
            Message = "The request was successfull";
            IsSuccess = true;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        public static Response ErrorResponse(List<string> errors)
        {
            return new Response
            {
                IsSuccess = false,
                Message = "Request validation failed. Please correct your request parameters",
                ResponseStatus = ResponseStatus.WARNING,
                Info = errors
            };
        }
    }

    public enum ResponseStatus
    {
        SUCCESS = 1,
        WARNING = 2,
        ERROR= 3,
        EXCEPTION= 4
    }    
}
