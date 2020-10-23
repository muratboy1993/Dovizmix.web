using Data.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Exchanges")]
    public partial class Exchanges : BaseEntity
    {
        public int MarketId { get; set; }
        
        public double LastBuyPrice { get; set; }

        public double LastSellPrice { get; set; }

        public double MarketCup { get; set; }

        public double MarketVolume { get; set; }

        public double MarketSupply { get; set; }

        //Yüzdelik Deðiþim Oraný
        public double Rate { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastUpdatedDateTime { get; set; }
        
        [ForeignKey("MarketId")]
        public virtual Markets Markets { get; set; } 
    }
}
