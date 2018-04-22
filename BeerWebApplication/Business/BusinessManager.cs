using BeerWebApplication.Class;
using BeerWebApplication.ClientApi;
using Newtonsoft.Json;
using System;
using System.Text;

namespace BeerWebApplication.Business
{
    public class BusinessManager
    {
        /// <summary>
        /// Create filter and fetch record from rest client api
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public BeerList FetchBeerList(SearchGrid search)
        {
            try
            {
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append("&sort=" + search.sord.ToUpper());
                sbQuery.Append("&order=" + search.sidx);
                sbQuery.Append("&p=" + search.page);
                if (search.filters != null && search.filters != "")
                {
                    var filterresult = JsonConvert.DeserializeObject<Class.Filter>(search.filters);
                    foreach (var rule in filterresult.rules)
                    {
                        if (rule.field == "name")
                            sbQuery.Append("&name=" + rule.data);
                        if (rule.field == "description")
                            sbQuery.Append("&description=" + rule.data);
                        if (rule.field == "description")
                            sbQuery.Append("&abv=" + rule.data);
                        if (rule.field == "abv")
                            sbQuery.Append("&abv=" + rule.data);
                        if (rule.field == "ibu")
                            sbQuery.Append("&ibu=" + rule.data);
                        if (rule.field == "glasswareId")
                            sbQuery.Append("&glasswareId=" + rule.data);
                        if (rule.field == "srmId")
                            sbQuery.Append("&srmId=" + rule.data);
                        if (rule.field == "availableId")
                            sbQuery.Append("&availableId=" + rule.data);
                        if (rule.field == "styleId")
                            sbQuery.Append("&styleId=" + rule.data);
                        if (rule.field == "isOrganic")
                            sbQuery.Append("&isOrganic=" + rule.data);
                        if (rule.field == "status")
                            sbQuery.Append("&status=" + rule.data);
                        if (rule.field == "createDate")
                            sbQuery.Append("&createDate=" + rule.data);
                        if (rule.field == "updateDate")
                            sbQuery.Append("&updateDate=" + rule.data);
                        if (rule.field == "random")
                            sbQuery.Append("&random=" + rule.data);

                    }
                }
                BeerList obj = new BeerList();
                RestClient rc = new RestClient();
                obj = rc.getResultBeerList(sbQuery.ToString());
                return obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public BeerDetail FetchBeerDetail(string Id)
        {
            try
            {
                BeerDetail beerDetail = new BeerDetail();
                RestClient rc = new RestClient();
                beerDetail = rc.getResultBeerDetail(Id);
                return beerDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}