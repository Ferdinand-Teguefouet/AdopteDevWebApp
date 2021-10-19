using DataAccess.Entities;
using DataAccess.Interface;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DataAccess.Services
{
    public class UserService : IService<User>
    {
        #region Properties
        private readonly string url = "https://localhost:44342/api/";

        private readonly HttpClient _client;
        #endregion
        #region Constructor
        public UserService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }
        #endregion
        #region Using DeleteAsync() to delete an element by id
        public void Delete(int _id, string _token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (HttpResponseMessage message = _client.DeleteAsync("user/" + _id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(message.StatusCode.ToString());
                }
            }
        }
        #endregion

        #region Using GetAsync() to read all
        public IEnumerable<User> GetAll(string _token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (HttpResponseMessage message = _client.GetAsync("user").Result)
            {
                //if (!message.IsSuccessStatusCode)
                //{
                //    throw new HttpRequestException();
                //}
                if (message.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(message.StatusCode.ToString());
                }
                string json = message.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<User>>(json);
            }
        }
        #endregion

        #region Using GetAsync() to read by id
        public User GetById(int _id)
        {
            using (HttpResponseMessage message = _client.GetAsync("user/" + _id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<User>(json);
            }
        }
        #endregion

        #region Using PostAsync() to insert / add
        public void Insert(User _obj)
        {
            //string jsonBody = JsonConvert.SerializeObject(_obj);

            //using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            //{
            //    using (HttpResponseMessage message = _client.PostAsync("user/register", content).Result)
            //    {
            //        if (!message.IsSuccessStatusCode)
            //        {
            //            throw new HttpRequestException(message.StatusCode.ToString());
            //        }
            //    }
            //}
        }
        #endregion

        #region Using PutAsync() to update
        public void Update(User _obj)
        {
            string json = JsonConvert.SerializeObject(_obj);

            using (HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _client.PutAsync("user", content).Result)
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
