//using System;
//using System.Threading.Tasks;
//using Microsoft.Bot.Builder.Dialogs;
//using Microsoft.Bot.Connector;

//namespace Bot_Application1.Dialogs
//{
//    [Serializable]
//    public class InitialOptionsDialog : IDialog<object>
//    {
//        public Task StartAsync(IDialogContext context)
//        {
//            context.Wait(MessageReceivedAsync);

//            return Task.CompletedTask;
//        }

//        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
//        {
//            var activity = await result as IMessageActivity;

//            // TODO: Put logic for handling user message here

//            context.Wait(MessageReceivedAsync);
//        }
//        private async Task OptionReceivedAsync(IDialogContext context, IAwaitable<InitOptions> result)
//        {
//            InitOptions response = await result;

//            context.Call<Object>(response.ToString(), ChildOptionReceived);

//        }

//        private Task ChildOptionReceived(IDialogContext context, IAwaitable<object> result)
//        {
//            throw new NotImplementedException();
//        }
//        private async Task ShowOptionsCard(IDialogContext context, IAwaitable<IMessageActivity> result)
//        {
//            var activity = await result;

//            PromptDialog.Choice(
//                context: context,
//                resume: OptionReceivedAsync,
//                options: (IEnumerable<InitOptions>)Enum.GetValues(typeof(InitOptions)),
//                prompt: "Please Select an Option:",
//                retry: "Selected option not available, please try again.",
//                promptStyle: PromptStyle.Auto
//                );

//        }

//    }
//}