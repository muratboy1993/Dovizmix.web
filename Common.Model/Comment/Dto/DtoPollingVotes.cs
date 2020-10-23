using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model.Comment.Dto
{
    public class DtoPollingVotes
    {
        public int UserId { get; set; }
        public int PollOptionId { get; set; }
        public int PollId { get; set; }
    }
}
