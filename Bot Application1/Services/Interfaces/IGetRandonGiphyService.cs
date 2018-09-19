using Bot_Application1.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Application1.Services.Interfaces
{
    public interface IGetRandonGiphyService
    {
        Attachment GetRandomGifBasedOnSearchCritera(string searchCritera);
    }
}