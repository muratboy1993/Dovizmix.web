using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model.DataProviders.Coin.Coingecko.Dto
{
    public class DtoCoingeckoCoin
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("current_price")]
        public double? CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public long? MarketCap { get; set; }

        [JsonProperty("market_cap_rank")]
        public double? MarketCapRank { get; set; }

        [JsonProperty("total_volume")]
        public long? TotalVolume { get; set; }


        [JsonProperty("total_supply", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalSupply { get; set; }


        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }

    
}
