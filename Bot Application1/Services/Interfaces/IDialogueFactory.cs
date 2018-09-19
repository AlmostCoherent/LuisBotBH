using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Application1.Services.Interfaces
{
    public interface IDialogueFactory
    {
        dynamic Create(int typeOfDialogue);
    }
}
