using System.Collections.Generic;

namespace Common.Model.Comment.Response
{
    public class ResComments
    {
        public int TotalCount { get; set; }
        public List<ResGetComments> ResGetComments { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SeoUrl { get; set; }
        public string QueryType { get; set; }
    }
}
