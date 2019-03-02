using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Webhook
{
    public class WebhookTrigger
    {
        /// <summary>
        /// Sends request to the IFTTT triggering the event connected with webhook 
        /// </summary>
        /// <param name="values">Dictionary with values that may be added to the POST request. Max 3 values may be used. Values may be equal to null 
        /// what will trigger only webhook with GET request.</param>
        /// <param name="eventName">IFTTT event name</param>
        /// <param name="secretKey">IFTTT secret key</param>
        /// <returns></returns>
        public static async Task SendRequestAsync(Dictionary<string, string> values, string eventName, string secretKey)
        {
            var client = new HttpClient();
            HttpResponseMessage response;

            if (values != null)
            {
                var content = new FormUrlEncodedContent(values);
                response = await client.PostAsync("https://maker.ifttt.com/trigger/" + eventName + "/with/key/" + secretKey, content);
            }
            else
            {
                response = await client.GetAsync("https://maker.ifttt.com/trigger/" + eventName + "/with/key/" + secretKey);
            }

            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}
