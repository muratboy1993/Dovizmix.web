using Common.Model.Utility;
using System.Text.RegularExpressions;

namespace Common.Model.ComplaintTopic.Request
{
    public class ReqCommentComplaint
    {
        private string _message;

        public int UserId { get; set; }
        public int CommentId { get; set; }
        public int TopicId { get; set; }
        public string Description {
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
    }
}
