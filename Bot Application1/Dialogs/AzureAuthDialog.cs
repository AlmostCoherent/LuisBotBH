//using System;
//using System.Threading.Tasks;
//using Microsoft.Bot.Builder.Dialogs;
//using Microsoft.Bot.Connector;
//using Microsoft.Bot.Builder.Dialogs.Internals;
//using System.Text.RegularExpressions;

//namespace Bot_Application1.Dialogs
//{
//    [Serializable]
//    public class AzureAuthDialog : IDialog<object>
//    {
//        protected string _ResourceId { get; set; }
//        protected string[] _Scopes { get; set; }
//        protected string _Prompt { get; set; }
//        public AzureAuthDialog(string resourceId, string prompt = "Please click to sign in:")
//        {
//            _ResourceId = resourceId;
//            _Prompt = prompt;
//        }

//        public AzureAuthDialog(string[] scopes, string prompt = "Please click to sign in:")
//        {
//            _Scopes = scopes;
//            _Prompt = prompt;
//        }


//        public Task StartAsync(IDialogContext context)
//        {
//            context.Wait(MessageReceivedAsync);

//            return Task.CompletedTask;
//        }

//        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
//        {
//            var msg = await result;

//            AuthResult authResult;
//            string validated = "";
//            int magicNumber = 0;
//            if (context.UserData.TryGetValue(ContextConstants.AuthResultKey, out authResult))
//            {
//                try
//                {
//                    //IMPORTANT: DO NOT REMOVE THE MAGIC NUMBER CHECK THAT WE DO HERE. THIS IS AN ABSOLUTE SECURITY REQUIREMENT
//                    //REMOVING THIS WILL REMOVE YOUR BOT AND YOUR USERS TO SECURITY VULNERABILITIES. 
//                    //MAKE SURE YOU UNDERSTAND THE ATTACK VECTORS AND WHY THIS IS IN PLACE.
//                    context.UserData.TryGetValue<string>(ContextConstants.MagicNumberValidated, out validated);
//                    if (validated == "true")
//                    {
//                        context.Done($"Thanks {authResult.UserName}. You are now logged in. ");
//                    }
//                    else if (context.UserData.TryGetValue<int>(ContextConstants.MagicNumberKey, out magicNumber))
//                    {
//                        if (msg.Text == null)
//                        {
//                            await context.PostAsync($"Please paste back the number you received in your authentication screen.");

//                            context.Wait(this.MessageReceivedAsync);
//                        }
//                        else
//                        {

//                            if (msg.Text.Length >= 6 && magicNumber.ToString() == msg.Text.Substring(0, 6))
//                            {
//                                context.UserData.SetValue<string>(ContextConstants.MagicNumberValidated, "true");
//                                context.Done($"Thanks {authResult.UserName}. You are now logged in. ");
//                            }
//                            else
//                            {
//                                context.UserData.RemoveValue(ContextConstants.AuthResultKey);
//                                context.UserData.SetValue<string>(ContextConstants.MagicNumberValidated, "false");
//                                context.UserData.RemoveValue(ContextConstants.MagicNumberKey);
//                                await context.PostAsync($"I'm sorry but I couldn't validate your number. Please try authenticating once again. ");

//                                context.Wait(this.MessageReceivedAsync);
//                            }
//                        }
//                    }
//                }
//                catch
//                {
//                    context.UserData.RemoveValue(ContextConstants.AuthResultKey);
//                    context.UserData.SetValue(ContextConstants.MagicNumberValidated, "false");
//                    context.UserData.RemoveValue(ContextConstants.MagicNumberKey);
//                    context.Done($"I'm sorry but something went wrong while authenticating.");
//                }
//            }
//            else
//            {
//                await this.CheckForLogin(context, msg);
//            }
//        }
//    }
//}