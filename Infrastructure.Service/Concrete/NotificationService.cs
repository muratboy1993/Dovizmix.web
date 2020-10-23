using AutoMapper;
using Common.Model.Comment.Dto;
using Common.Model.Notification.Dto;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class NotificationService : INotificationService
    {
        private readonly ICommentLikesRepository _commentLikesRepository;
        private readonly ICommentNotificationRepository _commentNotificationRepository;
        private readonly IMapper _mapper;
        private readonly EFDBContext _context;

        public NotificationService(ICommentLikesRepository commentLikesRepository, IMapper mapper, EFDBContext context, ICommentNotificationRepository commentNotificationRepository)
        {
            _commentLikesRepository = commentLikesRepository;
            _mapper = mapper;
            _context = context;
            _commentNotificationRepository = commentNotificationRepository;
        }

        public async Task<DtoGetBaseComment> GetBaseComment(int notiId)
        {
            return await _commentNotificationRepository.GetBaseComment(notiId);
        }

        public async Task<List<int>> GetCommentId(int userId)
        {
            return await _commentNotificationRepository.GetCommentId(userId);
        }

        public async Task<int> AddCommentNotification(int userId, int commentId)
        {
            CommentNotifications not = new CommentNotifications();

            not.CommentId = commentId;
            not.UserId = userId;
            not.CreateDateTime = DateTime.Now;
            not.IsDelete = false;
            not.IsShown = false;

            await _commentNotificationRepository.Add(not);

            return not.Id;
        }

        public async Task<List<DtoGetLikes>> GetLikes(int userId)
        {
            return await _commentLikesRepository.GetLikeNotifications(userId);
        }

        //public async Task<List<DtoGetDislikes>> GetDislikes(int userId)
        //{
        //    return await _commentLikesRepository.GetDislikeNotifications(userId);
        //}

        public async Task<int> UpdateIsShown(List<DtoLikeOrDislike> likeOrDislike)
        {
            var map = _mapper.Map<List<CommentLikes>>(likeOrDislike);
            int a = 0;
            foreach (var item in map)
            {
                item.IsShown = true;
                a = await _commentLikesRepository.Update(item);
            }
            return a;
        }

        public async Task<DtoGetEntry> GetEntry(int id)
        {
            return _mapper.Map<DtoGetEntry>(await _commentNotificationRepository.GetById(id));
        }

        public async Task<int> UpdateIsShown(DtoGetEntry entry)
        {
            var map = _mapper.Map<CommentNotifications>(entry);
            map.IsShown = true;
            return await _commentNotificationRepository.Update(map);
        }

        public async Task<int> UpdateIsDelete(DtoGetEntry entry)
        {
            var map = _mapper.Map<CommentNotifications>(entry);
            map.IsDelete = true;
            return await _commentNotificationRepository.Update(map);
        }

        public async Task<int> GetNewNotificationCount(int userId)
        {
            return await _commentNotificationRepository.GetNewNotificationCount(userId);
        }

        public async Task<List<int>> GetNotificationIds(int userId)
        {
            return await _commentNotificationRepository.GetNotificationIds(userId);
        }

        public async Task<int> GetNotificationIdByComment(int commentId, int userId)
        {
            return await _commentNotificationRepository.GetNotificationIdByComment(commentId, userId);
        }

        public async Task<List<int>> GetNotificationsIds(int userId)
        {
            return await _commentNotificationRepository.GetNotificationsIds(userId);
        }
    }
}
