using System;

namespace Common.Model.Comment.Dto
{
    public class DtoAddComments
    {
        public int UserId { get; set; }
        public int MarketId { get; set; }
        public string Message { get; set; }
        public int? CommentParentId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsDelete { get; set; }
        public bool IsPinned { get; set; }
        public string CommentIp { get; set; }
    }
}
