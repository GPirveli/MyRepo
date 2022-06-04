using DocumentFormat.OpenXml.Bibliography;
using PersonManagement.Service.Abstractions;
using PersonManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Service.Implementations
{
    public class ActivityService : IActivityService
    {
        static HttpClient client = new HttpClient();

        string path = "http://www.boredapi.com/api/activity";
        public async Task<string> GetAllAsync()
        {

            //HttpResponseMessage response = await client.GetAsync(path);
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            //return responseBody;

            using var client = new HttpClient();
            var content = await client.GetStringAsync(path);
            return content;
        }
    }
}
