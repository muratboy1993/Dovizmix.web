using Data.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("MarketTypes")]
    public class MarketTypes : BaseEntity
    {
        public string Type { get; set; }

        public virtual List<Markets> Markets { get; set; }
    }
}
