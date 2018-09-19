using Bot_Application1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Configuration;
using Bot_Application1.Tools;

namespace Bot_Application1.Services.Implementations
{
    [Serializable]
    public class GetLuisResult : IGetLuisResult
    {
        private string uri = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/" + 
            ConfigurationManager.AppSettings["LuisAppId"] + "?";
        public string GetLuisIntent(string userStringQuery)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["q"] = HttpUtility.UrlEncode(userStringQuery);

            queryString["subscription-key"] = ConfigurationManager.AppSettings["LuisSubscriptionKey"];

            queryString["timezoneOffset"] = "0";
            queryString["verbose"] = "false";
            queryString["spellCheck"] = "false";
            queryString["staging"] = "false";


            string jsonResponse = GetHttpResponse.GetJsonResponse(uri, queryString);


            return jsonResponse;
        }
    }
}