using System;

namespace Common.Model.Investment.Dto
{
    public class DtoUpdateInvestment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MarketId { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
