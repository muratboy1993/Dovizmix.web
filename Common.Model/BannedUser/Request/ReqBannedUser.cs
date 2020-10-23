using Common.Model.Utility;
using System;
using System.Text.RegularExpressions;

namespace Common.Model.BannedUser.Request
{
    public class ReqBannedUser
    {
        private string _message;
        
        public int UserId { get; set; }
        public DateTime BanEndTime { get; set; }


        public string Reason {
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
