using Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CommentComplaints")]
    public partial class CommentComplaints : BaseCommentComplaint
    {
        public string State { get; set; }

        [ForeignKey("TopicId")]
        public virtual ComplaintTopics ComplaintTopics { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comments Comments { get; set; }

    }
}
