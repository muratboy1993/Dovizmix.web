using Common.Model.Utility;
using System;
using System.Text.RegularExpressions;

namespace Common.Model.Investment.Request
{
    public class ReqAddInvestment
    {
        private string _message;

        public int UserId { get; set; }
        public int MarketId { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public string Note {
            get
            {
                return _message;
            }
            set
            {
                _message = BadWordFilter.BadWord(value);
                if (_message !=null)
                {
                    _message = Regex.Replace(_message, "<script[\\s\\S]*?>[\\s\\S]*?</script>", "");
                    _message = Regex.Replace(_message, @"<[^>]+>|&nbsp;", "").Trim();
                }
                
            }
        }
        public DateTime PurchaseDateTime { get; set; }
    }
}
