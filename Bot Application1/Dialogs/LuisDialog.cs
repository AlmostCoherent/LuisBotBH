using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Bot_Application1.Models;
using System.Configuration;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Bot_Application1.Services.Interfaces;
using System.Threading;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class LuisDialog : LuisDialog<object>
    {
        IGetRandonGiphyService _getRandonGiphyService;
        
        public LuisDialog(IGetRandonGiphyService getRandonGiphyService) : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisSubscriptionKey"], 
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
            _getRandonGiphyService = getRandonGiphyService;
        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await ShowLuisResult(context, result);
        }

        [LuisIntent("TestLuis")]
        public async Task LuisTest(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            await ShowLuisResult(context, result);
        }

        [LuisIntent("BotTest")]
        public async Task BotTest(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            await ShowLuisResult(context, result);
        }

        [LuisIntent("FindFilm")]
        public async Task FilmTest(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            await ShowLuisResult(context, result);
        }

        [LuisIntent("ShowMePicture")]
        public async Task ShowMePicture(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            await context.Forward(new GetImageDialog(_getRandonGiphyService), CallBackAfterLuis, context.Activity, CancellationToken.None);
        }

        private async Task ShowLuisResult(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached {result.Intents[0].Intent}. You said: {result.Query}");
            context.Wait(MessageReceived);
        }
        //private async Task ShowLuisResult(IDialogContext context, IAwaitable<LuisResult> result)
        //{
        //    var luisResult = result.GetAwaiter().GetResult();
        //    await context.PostAsync($"You have reached {luisResult.Intents[0].Intent}. You said: { luisResult.Query }");
        //    context.Wait(MessageReceived);
        //}

        private async Task CallBackAfterLuis(IDialogContext context, IAwaitable<IMessageActivity> awaitable)
        {
            await context.PostAsync("...");
        }

    }
}