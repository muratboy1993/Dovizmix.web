namespace Data.Entities.Abstract
{
    public abstract class BaseCommentGraphic : BaseEntity
    {
        public int CommentId { get; set; }

        public string GraphicPath { get; set; }
    }
}
