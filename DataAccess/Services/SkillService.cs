using DataAccess.Entities;
using DataAccess.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class SkillService : IService<Skill>
    {
        #region Properties
        private string url = "https://localhost:44342/api/";

        private readonly HttpClient _client;
        #endregion
        #region Constructor
        public SkillService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }
        #endregion
        #region Using DeleteAsync() to delete an element by id
        public void Delete(int _id, string _token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (HttpResponseMessage message = _client.DeleteAsync("skill/" + _id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(message.StatusCode.ToString());
                }
            }
        }
        #endregion

        #region Using GetAsync() to read all
        public IEnumerable<Skill> GetAll(string _token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (HttpResponseMessage message = _client.GetAsync("skill/").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
                string json = message.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<Skill>>(json);
            }
        }
        #endregion

        #region Using GetAsync() to read by id
        public Skill GetById(int _id)
        {
            using (HttpResponseMessage message = _client.GetAsync("skill/" + _id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Skill>(json);
            }
        }
        #endregion

        #region Using PostAsync() to insert / add
        public void Insert(Skill _obj)
        {
            string jsonBody = JsonConvert.SerializeObject(_obj);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _client.PostAsync("skill", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(message.StatusCode.ToString());
                    }
                }
            }
        }
        #endregion

        #region Using PutAsync() to update
        public void Update(Skill _obj)
        {
            string json = JsonConvert.SerializeObject(_obj);

            using (HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _client.PutAsync("skill", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(message.StatusCode.ToString());
                    }
                }
            }
        }
        #endregion
    }
}
