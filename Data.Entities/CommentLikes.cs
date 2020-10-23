using Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CommentLikes")]
    public class CommentLikes : BaseCommentLike
    {
        public bool IsShown { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comments Comments { get; set; }
    }
}
