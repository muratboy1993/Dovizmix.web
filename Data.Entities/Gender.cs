using Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Gender")]
    public partial class Gender : BaseEntity
    {
        public string Genders { get; set; }
    }
}
