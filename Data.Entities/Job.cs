using Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Job")]
    public partial class Job : BaseEntity
    {
        public string Jobs { get; set; }
    }
}
