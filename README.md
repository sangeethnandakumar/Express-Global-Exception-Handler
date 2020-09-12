# Express-Global-Exception-Handler
Global exception handler and Standard Response for ASP.NET Core Web APIs

Express Global exception handler integrates seamlessly into your .NET Core Web API project and provides error response in http response. It includes and uses a standard API response JSON that your application can use on any endpoint. Integration is seamless

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
