using System;

namespace Data.Entities.Abstract
{
    public abstract class BaseCommentLike : BaseEntity
    {
        public int CommentId { get; set; }

        //Beğenme yada beğenmeme işlemini yapanın idsi
        public int UserId { get; set; }

        //Beğenildiyse true beğenilmediyse false
        public bool LikedOrDisliked { get; set; }

        public DateTime LikedDateTime { get; set; }
    }
}
