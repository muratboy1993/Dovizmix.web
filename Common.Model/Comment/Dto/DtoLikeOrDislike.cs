using System;

namespace Common.Model.Comment.Dto
{
    public class DtoLikeOrDislike
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LikedDateTime { get; set; }
        public bool LikeOrDislike { get; set; }
        public int CommentId { get; set; }
        //Todo : Aykut IsShown eklendi bakılmalı
        public bool IsShown { get; set; }
    }

    public class DtoCheckLiked
    {
        public int Id { get; set; }
        public bool Choice { get; set; }
    }

    public class DtoLikeOrDislikeCount
    {
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}
