using System;

namespace Common.Model.Investment.Response
{
    public class ResGetAllInvestment
    {
        public int Id { get; set; }
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public string Note { get; set; }
    }
}
