using System;

namespace Common.Model.UserComplaint.Dto
{
    public class DtoGetUserComplaint
    {
        public string Username { get; set; }
        public string Topic { get; set; }
        public string Complaint { get; set; }
        public DateTime ComplaintDateTime { get; set; }
    }
}
