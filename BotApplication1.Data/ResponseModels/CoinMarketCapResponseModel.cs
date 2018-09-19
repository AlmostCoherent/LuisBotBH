using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication1.Data.ResponseModels
{
    public class CoinMarketCapResponseModel
    {
        public string total_market_cap_usd { get; set; }
        public string total_24h_volume_usd { get; set; }
        public string bitcoin_percentage_of_market_cap { get; set; }
        public string active_currencies { get; set; }
        public string active_assets { get; set; }
        public string active_markets { get; set; }
        public string availablelast_updated { get; set; }
    }
}
