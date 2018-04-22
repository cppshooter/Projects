using BeerWebApplication.Class;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;

namespace BeerWebApplication.ClientApi
{
    public class RestClient
    {
        private string apiKey = ConfigurationManager.AppSettings["apiKey"].ToString();//API Key to access web api
        private string apiUrl = ConfigurationManager.AppSettings["apiUrl"].ToString();//CLient API URL 
        public BeerList getResult(string filter)
        {
            BeerList obj = new BeerList();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(new Uri(apiUrl + "?key=" + apiKey + filter.ToString())).Result;

                    obj = JsonConvert.DeserializeObject<BeerList>(response);
                }
                return obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}