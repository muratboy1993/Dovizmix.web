using System;
using System.Collections.Generic;

namespace Common.Model.Comment.Response
{
    public class ResGetComments
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public string AvatarPath { get; set; }
        public byte UserLevel { get; set; }
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public int? CommentParentId { get; set; }
        public string ParentUsername { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public string Graphic { get; set; }
        public int? PollId { get; set; }
        public List<ResPollOptions> PollOptions { get; set; }
        public DateTime? PollStartDate { get; set; }
        public DateTime? PollEndDate { get; set; }
        public bool IsOnline { get; set; }
        public string PollOrGraphicUrl { get; set; }
        public bool IsSubscribe { get; set; }
        public int TotalPollVotes { get; set; }
        public ResUserPollVote UserPollVote { get; set; }
    }

    public class ResPollOptions
    {
        public string Option { get; set; }
        public int OptionId { get; set; }
        public int Vote { get; set; }
    }

    public class ResUserPollVote
    {
        public int? VoteId { get; set; }
        public bool IsVoted { get; set; }
    }
}
