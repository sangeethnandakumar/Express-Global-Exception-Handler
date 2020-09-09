using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressGlobalExceptionHandler
{
    public class Response<T, V>
    {
        public bool IsSuccess { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public List<string> Attributes { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Response()
        {
            Attributes = new List<string>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Response
    {
        public bool IsSuccess { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public List<string> Attributes { get; set; }
        public string Message { get; set; }

        public Response()
        {
            Attributes = new List<string>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public enum ResponseStatus
    {
        SUCCESS,
        INFO,
        WARNING,
        ERROR
    }
}
