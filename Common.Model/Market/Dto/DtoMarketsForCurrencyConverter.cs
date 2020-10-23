namespace Common.Model.Market.Dto
{
    public class DtoMarketsForCurrencyConverter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public byte Unit { get; set; }

        public string Icon { get; set; }

        public double? LastSellPrice { get; set; }

        public double? LastBuyPrice { get; set; }
    }
}
