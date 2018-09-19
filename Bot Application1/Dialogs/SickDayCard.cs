using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class SickDayCard : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as IMessageActivity;

            Activity replyToConversation = ((Activity)context.Activity).CreateReply();

            var hero = new HeroCard()
            {
                Title = "Demo Card Title",
                Subtitle = "Sub title",
                Text = "This is the body of the text.",
                Buttons = new List<CardAction>()
                {
                    new CardAction()
                    {
                        Text = "Yes",
                        Value = "yes"
                    },
                    new CardAction()
                    {
                        Text = "No",
                        Value = "no"
                    }
                }

            };


            // TODO: Put logic for handling user message here

            context.Wait(MessageReceivedAsync);
        }
    }
}