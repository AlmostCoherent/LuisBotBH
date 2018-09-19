using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Application1.Services.Interfaces
{
    public interface IDialogue
    {
        Task Attach(int typeOfDialogue);
    }
}
