using Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CommentPollVotes")]
    public class CommentPollVotes : BasePollVote
    {
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("PollOptionId")]
        public virtual CommentPollOptions CommentPollOptions { get; set; }

    }
}
