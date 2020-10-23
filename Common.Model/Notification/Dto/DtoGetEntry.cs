using System;

namespace Common.Model.Notification.Dto
{
    public class DtoGetEntry
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }

        //public int BaseCommentId { get; set; }
        //public int NotiCommentId { get; set; }
        //public int SourceUserId { get; set; }
        //public int TargetUserId { get; set; }
        public bool IsShown { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
