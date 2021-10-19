using DataAccess.Entities;
using DataAccess.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class LoginService : ILoginService
    {
        #region Properties
        private string url = "https://localhost:44342/api/";

        private readonly HttpClient _client;
        #endregion
        #region Constructor
        public LoginService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }
        #endregion
        public User Login(string _email, string _password)
        {
            string jsonBody = JsonConvert.SerializeObject(new { email = _email, password = _password });
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            string jsonResponse;
            using (HttpResponseMessage message = _client.PostAsync("user/login", content).Result)
            {
                //if (!message.IsSuccessStatusCode)
                //{
                //    throw new HttpRequestException();
                //}

                // Vérifie si le statut code est bon
                message.EnsureSuccessStatusCode();
                jsonResponse = message.Content.ReadAsStringAsync().Result;                
            }
            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }
    }
}
