using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assigment_V2.Model;

namespace Assigment_V2.Data
{
    public class AdultServiceA : IAdultServiceA
    {
        private HttpClient client;

        public AdultServiceA()
        {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultsAsync() {
            string uri = "http://dnp.metamate.me/Adults";
            HttpResponseMessage response = await client.GetAsync(uri);
            string message = await client.GetStringAsync(uri);
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task AddAdultsAsync(Adult adult)
        {
            string todoSerialized = JsonSerializer.Serialize(adult);

            StringContent content = new StringContent(
                todoSerialized,
                Encoding.UTF8,
                "application/json"
            );

            Console.Out.WriteLine(todoSerialized);

            HttpResponseMessage response = await client.PutAsync("http://dnp.metamate.me/Adults", content);
            Console.Out.WriteLine(response.ToString());
        }

        public async Task RemoveAdultsAsync(int personId)
        {
            await client.DeleteAsync($"http://dnp.metamate.me/Adults/{personId}");
        }

        public async Task UpdateAdultsAsync(Adult adult)
        {
            string todoAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"http://dnp.metamate.me/Adults", content);
        }
    }
}