using System;

namespace Common.Model.BannedUser.Dto
{
    public class DtoBannedUser
    {
        public int UserId { get; set; }
        public DateTime BanEndTime { get; set; }
        public string Reason { get; set; }
    }
}

