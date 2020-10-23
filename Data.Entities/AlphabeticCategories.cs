using Data.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("AlphabeticCategories")]
    public class AlphabeticCategories : BaseEntity
    {
        public string Category { get; set; }

        public virtual List<EconomicDictionary> EconomicDictionary { get; set; }
        public virtual List<Formations> Formations { get; set; }
    }
}
