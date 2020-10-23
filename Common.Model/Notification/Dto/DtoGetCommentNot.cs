using Common.Model.Comment.Dto;
using System.Collections.Generic;

namespace Common.Model.Notification.Dto
{
    public class DtoGetCommentNot
    {
        //Yeni yapılan yorum(alttakinin cevabı)
        public List<DtoGetComments> Comments { get; set; }
        //Ana yorum
        public List<DtoGetComments> ParentComment { get; set; }
    }
}