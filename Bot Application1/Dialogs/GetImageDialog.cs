using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Bot_Application1.Services.Interfaces;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class GetImageDialog : IDialog<IMessageActivity>
    {
        IGetRandonGiphyService _getRandomGiphyService;

        public GetImageDialog(IGetRandonGiphyService getRandonGiphyService)
        {
            _getRandomGiphyService = getRandonGiphyService;
        }
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
    }
}