using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using Bot_Application1.Services.Interfaces;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Bot_Application1.Services.Implementations;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class InitialDialog : IDialog<IMessageActivity>
    {
        IGetRandonGiphyService _getRandomGiphyService;
        IGetCoinmarketCapService _getCoinmarketCapService;
        IGetLuisResult _getLuisResult;

        public InitialDialog(IGetCoinmarketCapService getCoinmarketCapService, IGetRandonGiphyService getRandonGiphyService, IGetLuisResult getLuisResult)
        {
            _getRandomGiphyService = getRandonGiphyService;
            _getCoinmarketCapService = getCoinmarketCapService;
            _getLuisResult = getLuisResult;
        }

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message.Text != "")
            {
                var luisReturn = _getLuisResult.GetLuisIntent(message.Text);
            }

            await this.ShowWelcomeMessage(context);
        }

        private async Task ShowWelcomeMessage(IDialogContext context)
        {
            var reply = context.MakeMessage();

            var hero = new HeroCard();
            hero.Title = "Please select an option:";
            hero.Images = new List<CardImage>() { new CardImage("http://lorempixel.com/output/abstract-q-c-275-113-1.jpg") };
            hero.Buttons = new List<CardAction>(){
                    new CardAction(type: ActionTypes.PostBack ,value: "1", title: "Show me Kittens!!"),
                    new CardAction(type: ActionTypes.PostBack ,value: "0", title: "Check Market Cap")
            };

            reply.Attachments.Add(hero.ToAttachment());

            await context.PostAsync(reply);

            context.Wait(this.ChildDialog);

        }

        private async Task ChildDialog(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var res = await result;
            if(res.Text == "1")
            {
                await ShowMeKittens(context);
            }
            else
            {
                await ShowMarketCapThenBackToWelcome(context);
            }


        }

        private async Task ShowMeKittens(IDialogContext context)
        {
            var returnGiphyGif = _getRandomGiphyService.GetRandomGifBasedOnSearchCritera("kitten");

            var reply = context.MakeMessage();
            reply.Attachments.Add(returnGiphyGif);
            await context.PostAsync(reply);

            await this.ShowWelcomeMessage(context);
        }

        private async Task ShowMarketCapThenBackToWelcome(IDialogContext context)
        {
            var returnMarketCap = _getCoinmarketCapService.GetMarketCap();

            var reply = context.MakeMessage();
            reply.Attachments.Add(returnMarketCap);
            await context.PostAsync(reply);

            await this.ShowWelcomeMessage(context);
        }
    }
}