using Common.Model.Comment.Response;
using System.Collections.Generic;

namespace Common.Model.Notification.Response
{
    public class ResGetCommentNot
    {
        //Yeni yapılan yorum(alttakinin cevabı)(parent)
        public List<ResGetComments> Comments { get; set; }
        //Ana yorum
        public List<ResGetComments> ParentComment { get; set; }
    }
}