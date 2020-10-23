using Data.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CommentNotifications")]
    public class CommentNotifications : BaseEntity
    {
        public int CommentId { get; set; }
        
        public int UserId { get; set; }

        public bool IsShown { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreateDateTime { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comments BaseComment { get; set; }
        
        [ForeignKey("UserId")]
        public virtual Users TargetUsers { get; set; }

    }
}
