using System;

namespace Common.Model.Notification.Response
{
    public class ResGetCommentResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AvatarPath { get; set; }
        public string Comment { get; set; }
        public string MarketSeoUrl { get; set; }
        public string MarketName { get; set; }
        public bool IsShown { get; set; }
        public DateTime CreateDateTime { get; set; }
        public ResGetBaseComment BaseComment { get; set; }

        public class ResGetBaseComment
        {
            public string BaseComment { get; set; }
            public string BaseUsername { get; set; }
            public DateTime BaseCreateDateTime { get; set; }
        }
    }
}
