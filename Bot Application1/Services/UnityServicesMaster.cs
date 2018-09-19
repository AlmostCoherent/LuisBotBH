using Bot_Application1.Dialogs;
using Bot_Application1.Services.Implementations;
using Bot_Application1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Bot_Application1.Services
{
    public class UnityServicesMaster
    {
        public UnityServicesMaster()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IGetCoinmarketCapService, GetCoinmarketCapService>();
            container.RegisterType<IGetRandonGiphyService, GetRandomGiphyService>();
            container.RegisterType<IGetLuisResult, GetLuisResult>();
        }


    }
}