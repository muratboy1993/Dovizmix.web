using Common.Model.Utility;
using System.Text.RegularExpressions;

namespace Common.Model.Comment.Request
{
    public class ReqAddComments
    {
        private string _message;

        public int UserId { get; set; }
        public int MarketId { get; set; }

        public string Message {
            get
            {
                return _message;
            }
            set
            {
                _message = BadWordFilter.BadWord(value);
                _message = Regex.Replace(_message, "<script[\\s\\S]*?>[\\s\\S]*?</script>", "");
                _message = Regex.Replace(_message, @"<[^>]+>|&nbsp;", "").Trim();
            }
        }

        public int? CommentParentId { get; set; }
        public int? CommentId { get; set; }
        public string GraphicPath { get; set; }
        public int LastViewedCommentId { get; set; }
        public string QueryType { get; set; }
        public int PageCount { get; set; }
        //public int OnlineUserId { get; set; }
    }
}
