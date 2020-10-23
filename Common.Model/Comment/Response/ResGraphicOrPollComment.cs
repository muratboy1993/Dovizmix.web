using System.Collections.Generic;

namespace Common.Model.Comment.Response
{
    public class ResGraphicOrPollComment
    {
        public List<ResGetComments> GraphicOrPollResponses { get; set; }
        public ResGetComments GraphicOrPoll { get; set; }
    }
}
