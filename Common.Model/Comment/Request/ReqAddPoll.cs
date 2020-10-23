using Common.Model.Utility;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Common.Model.Comment.Request
{
    public class ReqAddPoll
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
        public string GraphicPath { get; set; }
        public IFormFile Graphic { get; set; }
        public int CommentId { get; set; }
        public sbyte Days { get; set; }
        public int PollId { get; set; }
        public List<string> Options { get; set; }
    }
}
