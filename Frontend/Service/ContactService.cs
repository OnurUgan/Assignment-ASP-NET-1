using Frontend.Models;
using Frontend.Models.DTO;
using Newtonsoft.Json;
using System.Text;
using System;
using Backend.Filters;

namespace Frontend.Service
{
    public class ContactsService
    {

        private readonly HttpClient _httpClient;
        //private readonly ApiKey _apiKey;

        public ContactsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task CreateMessage(MessageModel message)
        {


            var json = JsonConvert.SerializeObject(message);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsJsonAsync($"https://localhost:7003/api/Message?key=MyKey", message);
            response.EnsureSuccessStatusCode();

        }

    }
}