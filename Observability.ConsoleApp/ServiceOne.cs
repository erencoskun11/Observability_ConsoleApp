using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observability.ConsoleApp
{
    internal class ServiceOne
    {
        static HttpClient httpClient = new HttpClient();
        internal async Task<int> MakeRequestToGoogle()
        {

            using var activity = ActivitySourceProvider.Source.StartActivity(kind: System.Diagnostics.ActivityKind.Producer,name : "CustomMakeRequestToGoogle");

            var eventsTags = new ActivityTagsCollection();
            eventsTags.Add("userId",30);

            activity?.AddEvent(new("Startes a request to Google",tags:eventsTags));


            var result = await httpClient.GetAsync("http://www.google.com");
            
            var responseContent = await result.Content.ReadAsStringAsync();

            return responseContent.Length;

        }


    }
}
