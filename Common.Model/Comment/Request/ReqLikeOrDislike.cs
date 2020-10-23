namespace Common.Model.Comment.Request
{
    public class ReqLikeOrDislike
    {
        public int UserId { get; set; }
        public bool LikeOrDislike { get; set; }
        public int CommentId { get; set; }
    }
}
