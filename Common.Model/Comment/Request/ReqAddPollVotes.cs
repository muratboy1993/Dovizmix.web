namespace Common.Model.Comment.Request
{
    public class ReqAddPollVotes
    {
        public int UserId { get; set; }
        public int PollOptionId { get; set; }
        public int PollId { get; set; }
    }
}
