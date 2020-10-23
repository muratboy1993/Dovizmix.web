using Data.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("DeletedUsers")]
    public class DeletedUsers : BaseEntity
    {
        public int UserId { get; set; }

        public DateTime DeleteDateTime { get; set; }
        
        //Silinme sebebi
        public string DeleteReason { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}
