# Express-Global-Exception-Handler
Global exception handler and Standard Response for ASP.NET Core Web APIs

Express Global exception handler integrates seamlessly into your .NET Core Web API project and provides error response in http response. It includes and uses a standard API response JSON that your application can use on any endpoint. Integration is seamless

### Package Manager
The library is available free on NuGet
https://www.nuget.org/packages/Twileloop.ExpressData

```nuget
Install-Package Twileloop.ExpressGlobalExceptionHandler -Version 1.0.0
```

### Repository Contents
This repo maintains 2 projects. The main library and a demo project to implement it

## Document Using Swagger
The demo project also includes documenting the API using Swagger. This will help you generate API docs or SDKs from swagger.json

### Register Exception Handler
After you reference the project from NuGet, Register the global exception handler to the request pipeline on Startup.cs inside Configure methord
```csharp
  app.UseGlobalExceptionHandler();
```

## Standard Response
The library also includes and uses a standard Response pattern. You can use that from your API endpoints easily which makes your API response reliable and standardised.
```csharp
return new Response<Model>
  {
    IsSuccess = true,
    Message = "The request is successfull",
    ResponseStatus = ResponseStatus.SUCCESS,
    Data = data
  };
  
//Or if there is no data payload

return new Response
  {
    IsSuccess = true,
    Message = "The request is successfull",
    ResponseStatus = ResponseStatus.SUCCESS
  };
```

## Implementing custom BadRequest
I recommend you to use a custom BadRequest that ejects error messages from your API. This makes the life of API integration developer much easier. A sample implementation is available on the demo project. Then your API endpoint will look like this
```csharp
[HttpPost]
public IActionResult Get(BindModel data) {
  //Validate request
  if (WeatherForecastValidator.ValidateGet(data).IsSuccess) {
    return Ok(new Response < List < string >> {
      Data = new List < string > {
        "Data A",
        "Data B"
      }
    });
  }
  else {
    return BadRequest(WeatherForecastValidator.ValidateGet(data));
  }
}
```

## Request Validator
The validator we use in the above request can look like this which ejects a Response object. You can implement it anyway you want
```csharp
public static class WeatherForecastValidator {
  private static List < string > Errors = new List < string > ();

  public static Response ValidateGet(BindModel data) {
    Errors.Clear();
    try {
      if (data.Age > 10) {
        Errors.Add("Age should be less than 10");
      }
      if (data.Name.Length > 10) {
        Errors.Add("The length of the name should be less than 10");
      }
      return Errors.Count > 0 ? Response.ErrorResponse(Errors) : new Response();
    }
    catch(Exception) {
      return Response.ErrorResponse(new List < string > {
        "Unable to validate the request"
      });
    }
  }

}
```
