using Common.Model.CommentComplaint.Dto;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface ICommentComplaintRepository : IEntityRepositoryBase<CommentComplaints>
    {
        /// <summary>
        /// Kullanıcının bir yorumu şikayet edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="commentId"></param>
        /// <returns>Bulduğu şikayetin Id'sini döndürür.</returns>
        Task<int> CheckCommentComplaint(int userId, int commentId);

        Task<List<DtoGetCommentComplaint>> GetCommentComplaint(int userId);

        Task<string> GetState(int complaintId);
    }
}
