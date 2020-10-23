using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("EconomicCalendar")]
   public class EconomicCalendar : BaseEntity
    {
        public string Subject { get; set; }

        public int CountryId { get; set; }

        public int MarketId { get; set; }

        public int Importance { get; set; }

        public DateTime SubjectDateTime { get; set; }

        //Açıklanan
        public double Actual { get; set; }
        //Beklenen
        public double Forecast { get; set; }
        //Önceki
        public double Previous { get; set; }

        [ForeignKey("CountryId")]
        public virtual Countries Countries { get; set; }
        
        [ForeignKey("MarketId")]
        public virtual Markets Markets { get; set; }
    }
}
