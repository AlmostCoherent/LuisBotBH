using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Application1.Services.Interfaces
{
    public interface IGetLuisResult
    {
        string GetLuisIntent(string userStringQuery);
    }
}