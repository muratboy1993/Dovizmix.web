using Data.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("FrozenUsers")]
    public class FrozenUsers : BaseEntity
    {
        public int UserId { get; set; }

        public DateTime FrozenDateTime { get; set; }

        //Hesabın Dondurulma sebebi
        public string FrozenReason { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}
