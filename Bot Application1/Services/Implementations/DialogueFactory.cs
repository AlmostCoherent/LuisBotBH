using Bot_Application1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bot_Application1.Enums;
using Bot_Application1.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;

namespace Bot_Application1.Services.Implementations
{
    public class DialogueFactory : IDialogueFactory
    {
        IGetCoinmarketCapService _getCoinmarketCapService;
        IGetRandonGiphyService _getRandonGiphyService;
        IGetLuisResult _getLuisResult;

        public DialogueFactory(IGetCoinmarketCapService getCoinmarketCapService, IGetRandonGiphyService getRandonGiphyService, IGetLuisResult getLuisResult)
        {
            _getCoinmarketCapService = getCoinmarketCapService;
            _getRandonGiphyService = getRandonGiphyService;
            _getLuisResult = getLuisResult;
        }

        public dynamic Create(int typeOfDialogue)
        {
            switch (typeOfDialogue)
            {
                case (int)DialogueEnums.InitialDialog:
                    return new InitialDialog(_getCoinmarketCapService, _getRandonGiphyService, _getLuisResult);
                case (int)DialogueEnums.LuisDialog:
                    return new LuisDialog(_getRandonGiphyService);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}