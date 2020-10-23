using Common.Model.Utility;
using System.Text.RegularExpressions;

namespace Common.Model.Feedback
{
    public class ReqFeedback
    {
        private string _message;
        private string _email;

        public string Email {
            get
            {
                return _email;
            }
            set
            {
                _email = BadWordFilter.BadWord(value);
                _email = Regex.Replace(_email, "<script[\\s\\S]*?>[\\s\\S]*?</script>", "");
                _email = Regex.Replace(_email, @"<[^>]+>|&nbsp;", "").Trim();
            }
        }
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
    }
}
