using Data.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Investments : BaseEntity
    {
        public int UserId { get; set; }
        public int MarketId { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("MarketId")]
        public virtual Markets Markets { get; set; }
    }
}
