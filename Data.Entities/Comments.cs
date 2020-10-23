using Data.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Comments")]
    public partial class Comments : BaseComment
    {
        public int MarketId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("MarketId")]
        public virtual Markets Markets { get; set; }
        
        public virtual List<CommentComplaints> CommentComplaints { get; set; }

        public virtual List<CommentGraphics> CommentGraphics { get; set; }

        public virtual CommentPolls CommentPolls { get; set; }

        public virtual List<CommentLikes> CommentLikes { get; set; }

        public virtual List<CommentNotifications> BaseComment { get; set; }
        
    }
}
