using Bot_Application1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotApplication1.Data.ResponseModels;
using Microsoft.Bot.Connector;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Bot_Application1.Tools;

namespace Bot_Application1.Services.Implementations
{
    [Serializable]
    public class GetCoinmarketCapService : IGetCoinmarketCapService
    {
        public Attachment GetMarketCap()
        {
            string coinmarketCapEndPoint = "https://api.coinmarketcap.com/v1/global/";

            string jsonResponse = GetHttpResponse.GetJsonResponse(coinmarketCapEndPoint);

            CoinMarketCapResponseModel coinMarketCapResponse = JsonConvert.DeserializeObject<CoinMarketCapResponseModel>(jsonResponse);

            var returnHero = CreateContextCard.GetHeroCard(coinMarketCapResponse.total_market_cap_usd.AddCommasAndCultureInfo("$"));

            return returnHero;
        }
    }
}