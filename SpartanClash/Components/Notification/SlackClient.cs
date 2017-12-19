using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Notification
{
    public class SlackClient
    {
        private readonly Uri _webhookUrl;
        private readonly HttpClient _httpClient = new HttpClient();

        public SlackClient(Uri webhookUrl)
        {
            _webhookUrl = webhookUrl;
        }

        public async Task<HttpResponseMessage> SendMessageAsync(string message,
            string channel = null, string username = null)
        {
            var payload = new
            {
                text = message,
                channel,
                username,
            };
            var serializedPayload = JsonConvert.SerializeObject(payload);
            var response = await _httpClient.PostAsync(_webhookUrl,
                new StringContent(serializedPayload, Encoding.UTF8, "application/json"));

            return response;
        }
    }
}
