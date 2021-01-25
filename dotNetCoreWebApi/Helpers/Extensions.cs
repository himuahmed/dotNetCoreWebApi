using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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

        public static void Headers(this HttpResponse httpresponse, int totalCount, int totalPage, int currentPage, int itemsPerPage)
        {
            var paginationHeaders = new PaginationHeaders(totalCount, totalPage, currentPage, itemsPerPage);
            httpresponse.Headers.Add("paginationHeaders",JsonConvert.SerializeObject(paginationHeaders));
            httpresponse.Headers.Add("Access-Control-Expose-Headers", "paginationHeaders");
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
