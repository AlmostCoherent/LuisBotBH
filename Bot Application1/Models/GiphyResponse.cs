using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1.Models
{
    public class GiphyResponse
    {
        [JsonProperty("data")]
        public GiphyProperty Data { get; set; }
    }

    public class GiphyProperty
    {
        [JsonProperty("bitly_gif_url")]
        public string GiphyShortUrl { get; set; }
        [JsonProperty("images")]
        public GiphyImages GiphyImages { get; set; }
    }

    public class GiphyImages
    {
        [JsonProperty("fixed_width")]
        public GiphyImageProperties GiphyInnerObject { get; set; }

    }

    public class GiphyImageProperties
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("mp4")]
        public string Mp4 { get; set; }
    }
}