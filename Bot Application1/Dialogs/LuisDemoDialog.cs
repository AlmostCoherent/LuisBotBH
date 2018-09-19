using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    [LuisModel("63b79dfb-2f17-47a4-b658-834bedfa361b", "e8ed78ec10214dbaa87d3721e6017e28")]
    public class LuisDemoDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as IMessageActivity;

            // TODO: Put logic for handling user message here

            context.Wait(MessageReceivedAsync);
        }

        public async Task luisDefault(IDialogContext context, LuisResult result)
        {

        }
    }
}