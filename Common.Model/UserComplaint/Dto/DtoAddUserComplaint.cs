namespace Common.Model.UserComplaint.Dto
{
    public class DtoAddUserComplaint
    {
        public int UserId { get; set; }

        public int TargetUserId { get; set; }

        public int TopicId { get; set; }

        public string Description { get; set; }
    }
}
