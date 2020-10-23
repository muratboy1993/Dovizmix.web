using Data.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Blocks")]
    public partial class Blocks : BaseEntity
    {
        //Blocklayan
        public int BlockedByUserId { get; set; }
        
        //Blocklanan
        public int BlockedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        [ForeignKey("BlockedByUserId")]
        public virtual Users BlockedByUsers { get; set; }

        [ForeignKey("BlockedUserId")]
        public virtual Users BlockedUsers { get; set; }
    }
}
