using Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("CommentGraphics")]
    public partial class CommentGraphics : BaseCommentGraphic
    {
        [ForeignKey("CommentId")]
        public virtual Comments Comments { get; set; }

    }
}
