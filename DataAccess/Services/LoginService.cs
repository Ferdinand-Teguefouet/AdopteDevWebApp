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
        public UserLog GetByEmail(string _email)
        {
            using (HttpResponseMessage message = _client.GetAsync("User/login/" + _email).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<UserLog>(json);
            }
        }
    }
}
