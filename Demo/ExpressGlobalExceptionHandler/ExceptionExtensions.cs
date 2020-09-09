using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressGlobalExceptionHandler
{
    public static class ExceptionExtensions
    {
        //public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
        //{
        //    app.UseExceptionHandler(builder =>
        //    {
        //        builder.Run(async context =>
        //        {
        //            context.Response.Redirect("/Home/Error");
        //        });
        //    });
        //}

        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
