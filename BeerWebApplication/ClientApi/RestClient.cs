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
        private string apiBeerListUrl = ConfigurationManager.AppSettings["apiBeerListUrl"].ToString();//CLient API URL 
        private string apiBeerDetailUrl = ConfigurationManager.AppSettings["apiBeerDetailUrl"].ToString();//CLient API URL 
        public BeerList getResultBeerList(string filter)
        {
            BeerList obj = new BeerList();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(new Uri(apiBeerListUrl + "?key=" + apiKey + filter.ToString())).Result;

                    obj = JsonConvert.DeserializeObject<BeerList>(response);
                }
                return obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public BeerDetail getResultBeerDetail(string Id)
        {
            BeerDetail obj = new BeerDetail();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(new Uri(apiBeerDetailUrl + Id + "?key=" + apiKey)).Result;

                    obj = JsonConvert.DeserializeObject<BeerDetail>(response);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}