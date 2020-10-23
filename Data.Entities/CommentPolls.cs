using Data.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CommentPolls")]
    public partial class CommentPolls : BasePoll
    {
        public virtual List<CommentPollOptions> CommentPollOptions { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comments Comments { get; set; }
    }
}
