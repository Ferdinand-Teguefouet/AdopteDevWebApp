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
    public class ContractService : IService<Contract>
    {
        #region Properties
        private string url = "https://localhost:44342/api/";

        private readonly HttpClient _client;
        #endregion
        #region Constructor
        public ContractService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }
        #endregion
        #region Using DeleteAsync() to delete an element by id
        public void Delete(int _id)
        {
            using (HttpResponseMessage message = _client.DeleteAsync("contract/" + _id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(message.StatusCode.ToString());
                }
            }
        }
        #endregion

        #region Using GetAsync() to read all
        public IEnumerable<Contract> GetAll()
        {
            using (HttpResponseMessage message = _client.GetAsync("contract/").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
                string json = message.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<Contract>>(json);
            }
        }
        #endregion

        #region Using GetAsync() to read by id
        public Contract GetById(int _id)
        {
            using (HttpResponseMessage message = _client.GetAsync("Contract/" + _id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Contract>(json);
            }
        }
        #endregion

        #region Using PostAsync() to insert / add
        public void Insert(Contract _obj)
        {
            string jsonBody = JsonConvert.SerializeObject(_obj);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _client.PostAsync("contract", content).Result)
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
        public void Update(Contract _obj)
        {
            string json = JsonConvert.SerializeObject(_obj);

            using (HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _client.PutAsync("contract", content).Result)
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
