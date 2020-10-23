using Data.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Countries")]
    public partial class Countries : BaseEntity
    {
        public string Name { get; set; }

        public string FlagCode { get; set; }
        
        public virtual OpenCloseMarkets OpenCloseMarkets { get; set; }

        public virtual List<EconomicCalendar> EconomicCalendars { get; set; }
    }
}
