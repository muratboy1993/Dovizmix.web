using AutoMapper;
using Common.Model.Comment.Dto;
using Data.Entities;
using Data.Repositories.DataAccess.EF.Abstract;
using Infrastructure.Service.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Service.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentLikesRepository _commentLikesRepository;
        private readonly ICommentGraphicRepository _commentGraphicRepository;
        private readonly IPollVotesRepository _pollVotesRepository;
        private readonly IPollCommentRepository _pollCommentRepository;
        private readonly IPollOptionRepository _pollOptionRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentService(ICommentRepository commentRepository, ICommentLikesRepository commentLikesRepository, ICommentGraphicRepository commentGraphicRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IPollVotesRepository pollVotesRepository, IPollCommentRepository pollCommentRepository, IPollOptionRepository pollOptionRepository)
        {
            _commentRepository = commentRepository;
            _commentLikesRepository = commentLikesRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _pollVotesRepository = pollVotesRepository;
            _commentGraphicRepository = commentGraphicRepository;
            _pollCommentRepository = pollCommentRepository;
            _pollOptionRepository = pollOptionRepository;
        }

        #region YorumSayılarınıDöndürenMetotlar
        public async Task<int> GetAllCommentCounts(int marketId)
        {
            return await _commentRepository.GetAllCommentCounts(marketId);
        }

        public async Task<int> GetAllCommentCounts(int marketId, int? userId)
        {
            return await _commentRepository.GetAllCommentCounts(marketId, userId);
        }

        public async Task<int> GetGraphicCommentCounts(int marketId)
        {
            return await _commentRepository.GetGraphicCommentCounts(marketId);
        }

        public async Task<int> GetGraphicCommentCounts(int marketId, int? userId)
        {
            return await _commentRepository.GetGraphicCommentCounts(marketId, userId);
        }

        public async Task<int> GetOnlyPollCounts(int marketId)
        {
            return await _commentRepository.GetOnlyPollCounts(marketId);
        }

        public async Task<int> GetOnlyPollCounts(int marketId, int? userId)
        {
            return await _commentRepository.GetOnlyPollCounts(marketId, userId);
        }

        public async Task<int> GetOnlyStarredCommentCounts(int marketId)
        {
            return await _commentRepository.GetOnlyStarredCommentCounts(marketId);
        }

        public async Task<int> GetOnlyStarredCommentCounts(int marketId, int? userId)
        {
            return await _commentRepository.GetOnlyStarredCommentCounts(marketId, userId);
        }

        public async Task<int> GetPollResponseCounts(int commentId)
        {
            return await _commentRepository.GetPollResponseCounts(commentId);
        }

        public async Task<int> GetPollResponseCounts(int commentId, int? userId)
        {
            return await _commentRepository.GetPollResponseCounts(commentId, userId);
        }
        #endregion

        #region YorumlarınBeğeniSayılarınınDöndürenMetotlar
        public async Task<int> CommentLikeCount(int commentId)
        {
            return await _commentRepository.CommentLikeCount(commentId);
        }

        public async Task<int> CommentDislikeCount(int commentId)
        {
            return await _commentRepository.CommentDislikeCount(commentId);
        }
        #endregion

        #region TümYorumlarıGetir
        public async Task<List<DtoGetComments>> GetAllComments(int rowCount, int marketId, int startPage)
        {
            return await _commentRepository.GetAllComments(rowCount, marketId, startPage);
        }

        public async Task<List<DtoGetComments>> GetAllComments(int rowCount, int marketId, int? userId, int startPage)
        {
            return await _commentRepository.GetAllComments(rowCount, marketId, userId, startPage);
        }
        #endregion

        #region GrafikİçerenYorumlarıGetir
        public async Task<List<DtoGetComments>> GetOnlyGraphicComments(int rowCount, int marketId, int startPage)
        {
            return await _commentRepository.GetOnlyGraphicComments(rowCount, marketId, startPage);
        }

        public async Task<List<DtoGetComments>> GetOnlyGraphicComments(int rowCount, int marketId, int? userId, int startPage)
        {
            return await _commentRepository.GetOnlyGraphicComments(rowCount, marketId, userId, startPage);
        }
        #endregion

        #region AnketleriGetir
        public async Task<List<DtoGetComments>> GetOnlyPolls(int rowCount, int marketId, int startPage)
        {
            return await _commentRepository.GetOnlyPolls(rowCount, marketId, startPage);
        }

        public async Task<List<DtoGetComments>> GetOnlyPolls(int rowCount, int marketId, int? userId, int startPage)
        {
            return await _commentRepository.GetOnlyPolls(rowCount, marketId, userId, startPage);
        }
        #endregion

        #region YıldızlıKullanıcılarınYorumlarınıGetir
        public async Task<List<DtoGetComments>> GetOnlyStarredUserComments(int rowCount, int marketId, int startPage)
        {
            return await _commentRepository.GetOnlyStarredUserComments(rowCount, marketId, startPage);
        }

        public async Task<List<DtoGetComments>> GetOnlyStarredUserComments(int rowCount, int marketId, int? userId, int startPage)
        {
            return await _commentRepository.GetOnlyStarredUserComments(rowCount, marketId, userId, startPage);
        }
        #endregion

        #region TakipEttiğimKullanıcılarınYorumları

        public async Task<List<DtoGetComments>> GetOnlySubscribedUserComments(int rowCount, int marketId, int? userId, int startPage)
        {
            return await _commentRepository.GetOnlySubscribedUserComments(rowCount, marketId, userId, startPage);
        }

        public async Task<int> GetOnlySubscribedUserCommentCounts(int marketId, int? userId)
        {
            return await _commentRepository.GetOnlySubscribedUserCommentCounts(marketId, userId);
        }

        #endregion

        #region AnketVeyaGrafiğeYapılanYorumlar

        public async Task<List<DtoGetComments>> GetGraphicOrPollReplies(int commentId)
        {
            return await _commentRepository.GetGraphicOrPollReplies(commentId);
        }

        public async Task<List<DtoGetComments>> GetGraphicOrPollReplies(int commentId, int? userId)
        {
            return await _commentRepository.GetGraphicOrPollReplies(commentId, userId);
        }

        #endregion

        #region YorumBeğenme

        /// <summary>
        /// Yorum beğenme/beğenmeme var mı yok mu diye kontrol ediyor.
        /// </summary>
        /// <param name="likedByUserId">Beğenen kullanıcının Id'si</param>
        /// <param name="relatedCommentId">Beğenilen/Beğenilmeyen yorumun Id'si</param>
        /// <returns>Varsa Id'si dönülüyor.</returns>
        public async Task<DtoCheckLiked> CheckLikedComment(int likedByUserId, int relatedCommentId)
        {
            return await _commentLikesRepository.CheckLikedComment(likedByUserId, relatedCommentId);
        }

        /// <summary>
        /// Gün içerisinde 3 kereden fazla beğenme/beğenmeme mevzusu kontrol ediliyor.
        /// </summary>
        /// <param name="likedByUserId">Beğenen kullanıcının Id'si</param>
        /// <param name="likedUserId">Beğenilen/Beğenilmeyen yorumun sahibinin Id'si</param>
        /// <param name="choice">Ankete verilen oyun türü true/false</param>
        /// <returns>Sayısı dönülüyor.</returns>
        public async Task<int> CheckLikeLimit(int likedByUserId, int likedUserId, bool choice)
        {
            return await _commentLikesRepository.CheckLikeLimit(likedByUserId, likedUserId, choice);
        }

        /// <summary>
        /// Verilen commentId'nin sahibinin UserId'si bulunuyor.
        /// </summary>
        /// <param name="commentId">Id</param>
        /// <returns>Id'si dönülüyor.</returns>
        public async Task<int> GetUserId(int commentId)
        {
            return await _commentLikesRepository.GetUserId(commentId);
        }

        /// <summary>
        /// Yorum beğenme işlemi gelen modele göre db'ye kaydediliyor.
        /// </summary>
        /// <param name="dto">Gelen model</param>
        /// <returns>Beğeni eklendikten sonra yorumun like ve dislike sayıları dönülüyor.</returns>
        public async Task<DtoLikeOrDislikeCount> AddLikedComment(DtoLikeOrDislike dto)
        {
            await _commentLikesRepository.Add(new CommentLikes
            {
                UserId = dto.UserId,
                LikedDateTime = DateTime.Now,
                LikedOrDisliked = dto.LikeOrDislike,
                CommentId = dto.CommentId
            });
            return new DtoLikeOrDislikeCount
            {
                LikeCount = await _commentRepository.CommentLikeCount(dto.CommentId),
                DislikeCount = await _commentRepository.CommentDislikeCount(dto.CommentId)
            };
        }
        /// <summary>
        /// Yorum beğenme işlemi güncelleniyor.
        /// </summary>
        /// <param name="dto">Gelen model</param>
        /// <param name="likeId">Id</param>
        /// <returns>Beğeni güncellendikten sonra yorumun like ve dislike sayıları dönülüyor.</returns>
        public async Task<DtoLikeOrDislikeCount> UpdateLikedComment(DtoLikeOrDislike dto, int likeId)
        {
            var map = _mapper.Map<CommentLikes>(dto);
            map.Id = likeId;
            map.LikedOrDisliked = dto.LikeOrDislike;
            map.LikedDateTime = DateTime.Now;
            //Todo : Aykut IsShown eklendi buraya bakılmalı.
            map.IsShown = false;
            await _commentLikesRepository.Update(map);

            return new DtoLikeOrDislikeCount
            {
                LikeCount = await _commentRepository.CommentLikeCount(dto.CommentId),
                DislikeCount = await _commentRepository.CommentDislikeCount(dto.CommentId)
            };
        }

        /// <summary>
        /// UserId'si verilen kullanıcının CommentLike Entry'lerini döndürür.
        /// </summary>
        /// <param name="userId">Yorum sahibinin UserId'si</param>
        /// <returns></returns>
        public async Task<List<DtoLikeOrDislike>> GetCommentLikeEntry(int userId)
        {
            return await _commentLikesRepository.GetCommentLikeEntries(userId);
        }

        //public async Task<List<DtoLikeOrDislike>> GetCommentDislikeEntry(int userId)
        //{
        //    return await _commentLikesRepository.GetCommentDislikeEntries(userId);
        //}

        #endregion

        //User Profile sayfasındaki kullanıcının grafik, anket, beğenilen ve tüm yorumlarının servisleri.
        #region TekKullanıcınınYorumlarınıGetir

        #region TümYorumlar

        /// <summary>
        /// User Profil sayfası için profil sahibinin tüm yorumlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rowCount"></param>
        /// <param name="startPage"></param>
        /// <returns></returns>
        public async Task<List<DtoGetComments>> GetAllUserComments(int userId, int rowCount, int startPage)
        {
            return await _commentRepository.GetAllUserComments(userId, rowCount, startPage);
        }
        /// <summary>
        /// User Profil sayfası için profil sahibinin tüm yorumlarının saysını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetAllUserCommentCount(int userId)
        {
            return await _commentRepository.GetAllUserCommentCount(userId);
        }

        #endregion

        #region Grafik

        /// <summary>
        /// User Profil sayfası için profil sahibinin grafik içeren yorumlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="onlineUserId"></param>
        /// <param name="rowCount"></param>
        /// <param name="startPage"></param>
        /// <returns></returns>
        public async Task<List<DtoGetComments>> GetUserGraphicComments(int userId, int rowCount, int startPage)
        {
            return await _commentRepository.GetUserGraphicComments(userId, rowCount, startPage);
        }
        /// <summary>
        /// User Profil sayfası için profil sahibinin grafik içeren yorumlarının sayısını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetUserGraphicCommentCount(int userId)
        {
            return await _commentRepository.GetUserGraphicCommentCount(userId);
        }

        #endregion

        #region Anket

        /// <summary>
        /// User Profil sayfası için profil sahibinin anket içeren yorumlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="onlineUserId"></param>
        /// <param name="rowCount"></param>
        /// <param name="startPage"></param>
        /// <returns></returns>
        public async Task<List<DtoGetComments>> GetUserPolls(int userId, int rowCount, int startPage)
        {
            return await _commentRepository.GetUserPolls(userId, rowCount, startPage);
        }
        /// <summary>
        /// User Profil sayfası için profil sahibinin anket içeren yorumlarının sayısını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetUserPollCount(int userId)
        {
            return await _commentRepository.GetUserPollCount(userId);
        }

        #endregion

        #region Beğenilen

        /// <summary>
        /// User Profil sayfası için profil sahibinin beğenilen yorumlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rowCount"></param>
        /// <param name="startPage"></param>
        /// <returns></returns>
        public async Task<List<DtoGetComments>> GetUserLikedComments(int userId, int rowCount, int startPage)
        {
            return await _commentRepository.GetUserLikedComments(userId, rowCount, startPage);
        }
        /// <summary>
        /// User Profil sayfası için profil sahibinin beğenilen yorumlarının sayısını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetUserLikedCount(int userId)
        {
            return await _commentRepository.GetUserLikedCount(userId);
        }

        #endregion

        #endregion

        /// <summary>
        /// Tek bir anket veya grafik yorumu getirir.
        /// </summary>
        /// <param name="pollId"></param>
        /// <returns></returns>
        public async Task<DtoGetComments> GetPollOrGraphicComment(int commentId)
        {
            return await _commentRepository.GetPollOrGraphicComment(commentId);
        }

        /// <summary>
        /// Gelen commentId'ye göre o comment'ı döndürür.
        /// </summary>
        /// <param name="commentId">Yorumun Id'si</param>
        /// <returns>DTOGetComments tipinde tek yorum döndürür.</returns>
        public async Task<DtoGetComments> GetComment(int commentId)
        {
            return await _commentRepository.GetComment(commentId);
        }

        /// <summary>
        /// Gelen commentId'ye göre o comment'ı döndürür.
        /// </summary>
        /// <param name="commentId">Yorumun Id'si</param>
        /// <returns>DTOGetComments tipinde tek yorum döndürür.</returns>
        public async Task<DtoGetComments> GetComment(int commentId, int userId)
        {
            return await _commentRepository.GetComment(commentId, userId);
        }


        /// <summary>
        /// Verilen commentId'nin sahibinin username'ini bulur.
        /// </summary>
        /// <param name="commentId">CommentParentId</param>
        /// <returns>Username döner.</returns>
        public async Task<string> GetUsername(int? commentId)
        {
            return await _commentRepository.GetUsername(commentId);
        }

        /// <summary>
        /// Verilen CommentId'nin commentParentId parametresini bulur.
        /// </summary>
        /// <param name="commentId">Yorumun id'si</param>
        /// <returns>CommentId'ye göre CommentParentId'sini döndürür.</returns>
        public async Task<int?> GetParentId(int commentId)
        {
            return await _commentRepository.GetParentId(commentId);
        }

        /// <summary>
        /// Online kullanıcı ankete oy kullanıp kullanmadığını bulur.
        /// </summary>
        /// <param name="userId">Online olan kullanıcının id'si</param>
        /// <param name="pollId">Anketin id'si</param>
        /// <returns>Kullanıcının hangi seçeneğe oy verdiği yani pollOptionId döner.</returns>
        public async Task<int> GetUserPollVote(int? userId, int? pollId)
        {
            return await _commentRepository.GetUserPollVote(userId, pollId);
        }

        /// <summary>
        /// İlgili ankete yapılan toplam oy sayısı verir.
        /// </summary>
        /// <param name="pollOptionId">Anketin seçeneğini belirtir.</param>
        /// <returns>Verilen anket seçeneğinin sayısını döndürür.</returns>
        public async Task<int> TotalVoteCount(int pollOptionId)
        {
            return await _commentRepository.TotalVoteCount(pollOptionId);
        }

        /// <summary>
        /// İlgili anketin anket seçenekleri, seçeneklerin idleri, ve her bir seçeneğin oy sayısını döndürür.
        /// </summary>
        /// <param name="pollId">Anketin Id'si</param>
        /// <returns>DTOPollOptions tipinde anketin seçeneklerini liste şeklinde döndürür.</returns>
        public async Task<List<DtoPollOptions>> GetPollOptions(int? pollId)
        {
            return await _commentRepository.GetPollOptions(pollId);
        }
        
        /// <summary>
        /// Gelen modele göre yorum database'e ekleniyor.
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Db'ye kaydedilip sonuç int olarak dönülüyor.</returns>
        public async Task<int> AddComment(DtoAddComments model)
        {
            Comments comment = new Comments();
            comment.MarketId = model.MarketId;
            comment.IsDelete = false;
            comment.CommentIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            comment.CommentParentId = model.CommentParentId;
            comment.CreatedDateTime = DateTime.Now;
            comment.IsPinned = false;
            comment.Message = model.Message;
            comment.UserId = model.UserId;
            await _commentRepository.Add(comment);

            return comment.Id;
        }

        /// <summary>
        /// Gelen modele göre graphic yorumu graphicComments tablosuna ekler.
        /// </summary>
        /// <returns></returns>
        public async Task<int> AddGraphic(DtoAddGraphicComments model)
        {
            return await _commentGraphicRepository.Add(new CommentGraphics
            {
                CommentId = model.CommentId,
                GraphicPath = model.GraphicPath
            });
        }

        /// <summary>
        /// Gelen modele göre ankete yapılan seçim db'ye kaydediliyor.
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Db'ye kaydedilip sonuç int olarak dönülüyor.</returns>
        public async Task<int> AddPollVote(DtoAddPollVotes model)
        {
            return await _pollVotesRepository.Add(new CommentPollVotes
            {
                UserId = model.UserId,
                PollOptionId = model.PollOptionId,
                CreateDateTime = DateTime.Now
            });
        }

        /// <summary>
        /// Message'ı verilen yorumun id'sini döndürür.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<int> GetCommentId(int pollId)
        {
            return await _commentRepository.GetCommentId(pollId);
        }

        /// <summary>
        /// CommentId'si verilen anketin PollId'sini döndürür.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public async Task<int> GetPollId(int commentId)
        {
            return await _commentRepository.GetPollId(commentId);
        }

        /// <summary>
        /// Anket ekleme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddPoll(DtoAddPollComment model)
        {
            CommentPolls poll = new CommentPolls();
            poll.CommentId = model.CommentId;
            poll.StartDate = DateTime.Now;
            poll.EndDate = DateTime.Now.AddDays(model.Days);
            await _pollCommentRepository.Add(poll);

            return poll.Id;
        }

        /// <summary>
        /// Anket seçeneklerini ekleme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddPollOption(DtoAddPollOptions model)
        {
            return await _pollOptionRepository.Add(new CommentPollOptions
            {
                Options = model.Options,
                PollId = model.PollId
            });
        }

        /// <summary>
        /// Verilen commentId'den sonra eklenen yorumları getirir.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public async Task<List<DtoGetComments>> GetAllAfterReply(int lastViewCommentId, int userId, int marketId)
        {
            return await _commentRepository.GetAllAfterReply(lastViewCommentId, userId, marketId);
        }

        /// <summary>
        /// Verilen commentId'den sonra eklenen yorumları getirir.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public async Task<List<DtoGetComments>> GetAllAfterReply(int lastViewCommentId, int marketId)
        {
            return await _commentRepository.GetAllAfterReply(lastViewCommentId, marketId);
        }

        public async Task<string> GetMessage(int commentId)
        {
            return await _commentRepository.GetMessage(commentId);
        }

        //public async Task<string> GetReponses(int commentId)
        //{
        //    return await _commentRepository.GetReponses(commentId);
        //}
    }
}
