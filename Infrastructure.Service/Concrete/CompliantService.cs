using AutoMapper;
using Common.Model.CommentComplaint.Dto;
using Common.Model.ComplaintTopic.Dto;
using Common.Model.UserComplaint.Dto;
using Data.Entities;
using Data.Repositories.DataAccess.EF.Abstract;
using Data.Repositories.DataAccess.EF.Concrete;
using Infrastructure.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class CompliantService : IComplaintService
    {
        private readonly IComplaintTopicRepository _complaintTopicRepository;
        private readonly ICommentComplaintRepository _commentCompliantRepository;
        private readonly IUserComplaintRepository _userCompliantRepository;
        private readonly IMapper _mapper;

        public CompliantService(ICommentComplaintRepository commentCompliantRepository, IComplaintTopicRepository complaintTopicRepository, IUserComplaintRepository userCompliantRepository, IMapper mapper)
        {
            _commentCompliantRepository = commentCompliantRepository;
            _complaintTopicRepository = complaintTopicRepository;
            _userCompliantRepository = userCompliantRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Yorum şikayeti işlemini yapar.
        /// </summary>
        /// <param name="complaint">UserId(şikayet eden),CommentId(Şikayet edilen),TopicId(seçilen konu),Description(Açıklama)</param>
        /// <returns></returns>
        public async Task<int> AddCommentComplaint(DtoCommentComplaint complaint)
        {
            CommentComplaints commentComplaints = new CommentComplaints
            {
                CommentId = complaint.CommentId,
                TopicId = complaint.TopicId,
                UserId = complaint.UserId,
                ComplaintDescription = complaint.Description,
                ComplaintDateTime = DateTime.Now
            };

            await _commentCompliantRepository.Add(commentComplaints);

            return commentComplaints.Id;
        }

        /// <summary>
        /// Kullanıcı şikayeti işlemini yapar.
        /// </summary>
        /// <param name="complaints">UserId(şikayet eden),TargetUserId(Şikayet edilen),TopicId(seçilen konu),Description(Açıklama)</param>
        /// <returns></returns>
        public async Task<int> AddUserComplaint(DtoAddUserComplaint complaint)
        {
            return await _userCompliantRepository.Add(new UserComplaints
            {
                ComplainantUserId = complaint.UserId,
                ComplainedUserId = complaint.TargetUserId,
                ComplaintDateTime = DateTime.Now,
                TopicOfComplaintId = complaint.TopicId,
                ComplaintDescription = complaint.Description
            });
        }

        /// <summary>
        /// Kullanıcının bir yorumu şikayet edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="commentId"></param>
        /// <returns>Bulduğu şikayetin Id'sini döndürür.</returns>
        public async Task<int> CheckCommentComplaint(int userId, int commentId)
        {
            return await _commentCompliantRepository.CheckCommentComplaint(userId, commentId);
        }

        /// <summary>
        /// Kullanıcının başka bir kullanıcıyı şikayet edip etmediğini kontrol eder.
        /// </summary>
        /// <param name="userId">Şikayet eden</param>
        /// <param name="targetUserId">Şikayet edilen</param>
        /// <returns></returns>
        public async Task<int> CheckUserComplaint(int userId, int targetUserId)
        {
            return await _userCompliantRepository.CheckUserComplaint(userId, targetUserId);
        }

        /// <summary>
        /// Topicleri ve Id'lerini getirir.
        /// </summary>
        /// <returns>Topicleri ve Idlerini döndürür.</returns>
        public List<DtoGetComplaintTopic> GetTopics()
        {
            return _complaintTopicRepository.GetAllTopics();
        }

        public async Task<List<DtoGetCommentComplaint>> GetCommentComplaint(int userId)
        {
            return await _commentCompliantRepository.GetCommentComplaint(userId);
        }

        public async Task<List<DtoGetUserComplaint>> GetUserComplaint(int userId)
        {
            return await _userCompliantRepository.GetUserComplaint(userId);
        }

        public async Task<string> GetTopic(int topicId)
        {
            return await _complaintTopicRepository.GetTopic(topicId);
        }

        public async Task<string> GetState(int complaintId)
        {
            return await _commentCompliantRepository.GetState(complaintId);
        }
    }
}
