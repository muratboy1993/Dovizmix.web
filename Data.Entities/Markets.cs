using Data.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Markets")]
    public partial class Markets : BaseEntity
    {
        public int TypeId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public byte Unit { get; set; }

        public string Icon { get; set; }

        public string SeoUrl { get; set; }

        public virtual List<Comments> Comments { get; set; }

        public virtual List<Exchanges> Exchanges { get; set; }

        [ForeignKey("TypeId")]
        public virtual MarketTypes MarketTypes { get; set; }

        public virtual List<Investments> Investments { get; set; }

        public virtual List<EconomicCalendar> EconomicCalendars { get; set; }
    }
}
