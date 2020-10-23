namespace Data.Entities.Abstract
{
    public abstract class BasePollOption : BaseEntity
    {
        public int PollId { get; set; }

        public string Options { get; set; }
    }
}
