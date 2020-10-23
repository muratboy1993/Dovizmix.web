using Data.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("ComplaintTopics")]
    public partial class ComplaintTopics : BaseEntity
    {
        public string Topic { get; set; }

        public virtual List<CommentComplaints> CommentComplaints { get; set; }

        public virtual List<UserComplaints> UserComplaints { get; set; }

    }
}
