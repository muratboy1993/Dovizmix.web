using Data.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("BannedUsers")]
    public class BannedUsers : BaseEntity
    {
        public int UserId { get; set; }

        public DateTime BanStartDateTime { get; set; }

        public DateTime BanEndDateTime { get; set; }

        //Ban sebebi
        public string BanReason { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}
