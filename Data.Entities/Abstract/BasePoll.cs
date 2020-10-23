using System;

namespace Data.Entities.Abstract
{
    public abstract class BasePoll :BaseEntity
    {

        public int CommentId { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
