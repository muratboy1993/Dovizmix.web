using System;

namespace Common.Model.CommentComplaint.Dto
{
    public class DtoGetCommentComplaint
    {
        public string Comment { get; set; }
        public string Username { get; set; }
        public string Topic { get; set; }
        public string Complaint { get; set; }
        public DateTime ComplaintDateTime { get; set; }
    }
}
