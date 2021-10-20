using DataAccess.Entities.FromViewsDb;
using DataAccess.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class ProfilDevService: IService<ProfilDev>
    {
        #region Properties
        private readonly string url = "https://localhost:44342/api/";

        private readonly HttpClient _client;
        #endregion
        #region Constructor
        public ProfilDevService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }

        public void Delete(int _id, string _token)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Using GetAsync() to read all
        public IEnumerable<ProfilDev> GetAll(string _token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            using (HttpResponseMessage message = _client.GetAsync("developper/profil").Result)
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
                return JsonConvert.DeserializeObject<IEnumerable<ProfilDev>>(json);
            }
        }

        public ProfilDev GetById(int _id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProfilDev _obj)
        {
            throw new NotImplementedException();
        }

        public void Update(ProfilDev _obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
