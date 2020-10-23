using System;

namespace Common.Model.Comment.Dto
{
    public class DtoAddPollVotes
    {
        public int UserId { get; set; }
        public int PollOptionId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
