using System;

namespace Common.Model.Comment.Dto
{
    public class DtoAddPollComment
    {
        public int CommentId { get; set; }
        public DateTime StartDate { get; set; }
        public sbyte Days { get; set; }
    }
}
