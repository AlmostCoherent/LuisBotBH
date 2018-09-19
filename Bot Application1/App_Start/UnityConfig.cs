using Bot_Application1.Dialogs;
using Bot_Application1.Services.Implementations;
using Bot_Application1.Services.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace Bot_Application1
{
    public static class UnityConfig
    {
        public static void RegisterComponents() 
        {
			var container = new UnityContainer();

            container.RegisterType<IGetCoinmarketCapService, GetCoinmarketCapService>();
            container.RegisterType<IGetRandonGiphyService, GetRandomGiphyService>();
            container.RegisterType<IGetLuisResult, GetLuisResult>();

            container.RegisterType<IDialog<IMessageActivity>, InitialDialog>("1");

            container.RegisterType<IDialogueFactory, DialogueFactory>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}