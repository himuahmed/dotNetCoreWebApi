using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace dotNetCoreWebApi.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse httpResponse,string message)
        {
            httpResponse.Headers.Add("Application-Error",message);
            httpResponse.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            httpResponse.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int GetAge(this DateTime dateTime)
        {
            var age = DateTime.Today.Year - dateTime.Year;
            if (dateTime.AddYears(age) > DateTime.Today)
            {
                age--;
            }

            return age;
        }
    }
}
