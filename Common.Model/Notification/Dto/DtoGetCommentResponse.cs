using System;

namespace Common.Model.Notification.Dto
{
    public class DtoGetCommentResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AvatarPath { get; set; }
        public string Comment { get; set; }
        public string MarketSeoUrl { get; set; }
        public string MarketName { get; set; }
        public bool IsShown { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DtoGetBaseComment BaseComment { get; set; }
    }
    public class DtoGetBaseComment
    {
        public string BaseComment { get; set; }
        public string BaseUsername { get; set; }
        public DateTime BaseCreateDateTime { get; set; }
    }
}
