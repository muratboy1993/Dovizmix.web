using Common.Model.CommentComplaint.Dto;
using Common.Model.ComplaintTopic.Dto;
using Common.Model.UserComplaint.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Abstract
{
    public interface IComplaintService
    {
        /// <summary>
        /// Topicleri ve Id'lerini getirir.
        /// </summary>
        /// <returns>Topicleri ve Idlerini döndürür.</returns>
        List<DtoGetComplaintTopic> GetTopics();

        /// <summary>
        /// Kullanıcının bir yorumu şikayet edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="commentId"></param>
        /// <returns>Bulduğu şikayetin Id'sini döndürür.</returns>
        Task<int> CheckCommentComplaint(int userId, int commentId);

        /// <summary>
        /// Kullanıcının başka bir kullanıcıyı şikayet edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="userId">Şikayet eden</param>
        /// <param name="targetUserId">Şikayet edilen</param>
        /// <returns></returns>
        Task<int> CheckUserComplaint(int userId, int targetUserId);

        /// <summary>
        /// Yorum şikayeti işlemini yapar.
        /// </summary>
        /// <param name="complaint">UserId(şikayet eden),CommentId(Şikayet edilen),TopicId(seçilen konu),Description(Açıklama)</param>
        /// <returns></returns>
        Task<int> AddCommentComplaint(DtoCommentComplaint complaint);

        /// <summary>
        /// Kullanıcı şikayeti işlemini yapar.
        /// </summary>
        /// <param name="complaint">UserId(şikayet eden),TargetUserId(Şikayet edilen),TopicId(seçilen konu),Description(Açıklama)</param>
        /// <returns></returns>
        Task<int> AddUserComplaint(DtoAddUserComplaint complaint);

        Task<List<DtoGetCommentComplaint>> GetCommentComplaint(int userId);

        Task<List<DtoGetUserComplaint>> GetUserComplaint(int userId);

        Task<string> GetTopic(int topicId);

        Task<string> GetState(int complaintId);
    }
}
