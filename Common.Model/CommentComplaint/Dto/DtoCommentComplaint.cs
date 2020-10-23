namespace Common.Model.ComplaintTopic.Dto
{
    public class DtoCommentComplaint
    {
        public int UserId { get; set; }

        public int CommentId { get; set; }

        public int TopicId { get; set; }

        public string Description { get; set; }
    }
}
