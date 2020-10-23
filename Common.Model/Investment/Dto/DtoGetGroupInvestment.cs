using System.Collections.Generic;

namespace Common.Model.Investment.Dto
{
    public class DtoGetGroupInvestment
    {
        public string MarketName { get; set; }

        public List<DtoGetAllInvestment> Investments { get; set; }
    }
}
