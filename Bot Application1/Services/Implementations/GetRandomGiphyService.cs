using Bot_Application1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bot_Application1.Models;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Bot.Connector;
using Bot_Application1.Tools;

namespace Bot_Application1.Services.Implementations
{
    [Serializable]
    public class GetRandomGiphyService : IGetRandonGiphyService
    {
        public Attachment GetRandomGifBasedOnSearchCritera(string searchCritera)
        {
            const string giphyApiKey = "ROSoLz0Iz8suznXXf1KOQ4a7RgjOSTS8";
            string giphyEndPoint = $"https://api.giphy.com/v1/gifs/random?api_key={giphyApiKey}&tag={searchCritera}&rating=G";

            string jsonResponse = GetHttpResponse.GetJsonResponse(giphyEndPoint);

            var stronglyTypedGiphyResponse = JsonConvert.DeserializeAnonymousType(jsonResponse, new GiphyResponse());

            List<MediaUrl> mediaUrl = new List<MediaUrl>();
            mediaUrl.Add(new MediaUrl()
            {
                Profile = "image/gif",
                Url = stronglyTypedGiphyResponse.Data.GiphyImages.GiphyInnerObject.Mp4
            });

            return CreateContextCard.GetAnimationCard(mediaUrl: mediaUrl, autoLoop: true, autoStart: true);

        }
    }
}