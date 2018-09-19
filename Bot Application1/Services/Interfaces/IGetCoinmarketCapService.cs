using BotApplication1.Data.ResponseModels;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1.Services.Interfaces
{
    public interface IGetCoinmarketCapService
    {
        Attachment GetMarketCap();
    }
}