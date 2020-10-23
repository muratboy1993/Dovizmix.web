using System;

namespace Data.Entities.Abstract
{
    public abstract class BaseCommentComplaint : BaseEntity
    {
        //Şikayet Eden
        public int UserId { get; set; }

        //Şikayet edilen yorum
        public int CommentId { get; set; }

        public int TopicId { get; set; }

        public string ComplaintDescription { get; set; }

        public DateTime ComplaintDateTime { get; set; }
    }
}
