using System;

namespace Data.Entities.Abstract
{
    public abstract class BaseComment : BaseEntity
    {
        public int UserId { get; set; }

        public string Message { get; set; }

        public int? CommentParentId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public bool IsDelete { get; set; }

        public bool IsPinned { get; set; }

        public string CommentIp { get; set; }
    }
}
