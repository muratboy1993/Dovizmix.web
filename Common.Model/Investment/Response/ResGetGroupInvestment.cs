using System.Collections.Generic;

namespace Common.Model.Investment.Response
{
    public class ResGetGroupInvestment
    {
        public string MarketName { get; set; }

        public List<ResGetAllInvestment> Investments { get; set; }
    }
}
