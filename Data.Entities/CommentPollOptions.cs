using Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CommentPollOptions")]
    public class CommentPollOptions : BasePollOption
    {
        [ForeignKey("PollId")]
        public virtual CommentPolls CommentPolls { get; set; }

    }
}
