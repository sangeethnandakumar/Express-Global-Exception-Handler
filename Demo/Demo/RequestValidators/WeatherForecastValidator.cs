using Demo.Models;
using ExpressGlobalExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.RequestValidators
{
    public static class WeatherForecastValidator
    {
        private static List<string> Errors = new List<string>();

        public static Response ValidateGet(BindModel data)
        {
            Errors.Clear();
            try
            {
                if (data.Age > 10)
                {
                    Errors.Add("Age should be less than 10");
                }
                if (data.Name.Length > 10)
                {
                    Errors.Add("The length of the name should be less than 10");
                }
                return Errors.Count > 0 ? Response.ErrorResponse(Errors) : new Response();
            }
            catch(Exception)
            {
                return Response.ErrorResponse(new List<string> { "Unable to validate the request" });
            }
        }

    }
}
