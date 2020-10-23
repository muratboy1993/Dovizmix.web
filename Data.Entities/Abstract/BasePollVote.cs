using System;

namespace Data.Entities.Abstract
{
    public abstract class BasePollVote : BaseEntity
    {
        public int UserId { get; set; }

        public int PollOptionId { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
