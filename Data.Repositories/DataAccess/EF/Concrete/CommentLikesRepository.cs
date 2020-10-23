using Common.Model.Comment.Dto;
using Common.Model.Notification.Dto;
using Data.Entities;
using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Concrete
{
    public class CommentLikesRepository : EntityRepositoryBase<CommentLikes>, ICommentLikesRepository
    {
        private readonly EFDBContext _context;
        public CommentLikesRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Yorum beğenme/beğenmeme var mı yok mu diye kontrol ediyor.
        /// </summary>
        /// <param name="likedByUserId">Beğenen kullanıcının Id'si</param>
        /// <param name="relatedCommentId">Beğenilen/Beğenilmeyen yorumun Id'si</param>
        /// <returns>Varsa Id'si dönülüyor.</returns>
        public async Task<DtoCheckLiked> CheckLikedComment(int likedByUserId, int relatedCommentId)
        {
            var query = await (from clikedcomment in _context.CommentLikes
                               where (likedByUserId == clikedcomment.UserId && relatedCommentId == clikedcomment.CommentId)
                               select new DtoCheckLiked
                               {
                                   Id = clikedcomment.Id,
                                   Choice = clikedcomment.LikedOrDisliked
                               }).SingleOrDefaultAsync();
            return query;
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
            var query = await (from clikedcomment in _context.CommentLikes
                               join comment in _context.Comments on clikedcomment.CommentId equals comment.Id
                               where (likedByUserId == clikedcomment.UserId && likedUserId == comment.UserId && choice == clikedcomment.LikedOrDisliked && DateTime.Now.AddDays(-1) <= clikedcomment.LikedDateTime)
                               select clikedcomment.LikedOrDisliked).CountAsync();
            return query;
        }

        /// <summary>
        /// Verilen commentId'nin sahibinin UserId'si bulunuyor.
        /// </summary>
        /// <param name="commentId">Id</param>
        /// <returns>Id'si dönülüyor.</returns>
        public async Task<int> GetUserId(int commentId)
        {
            var likedUsersId = await (from comment in _context.Comments
                                      where commentId == comment.Id
                                      select comment.UserId).SingleOrDefaultAsync();
            return likedUsersId;
        }
        
        public async Task<List<DtoGetLikes>> GetLikeNotifications(int userId)
        {
            var query = await (from like in _context.CommentLikes
                               join comment in _context.Comments on like.CommentId equals comment.Id
                               join user in _context.Users on comment.UserId equals user.Id
                               join us in _context.Users on like.UserId equals us.Id
                               join market in _context.Markets on comment.MarketId equals market.Id
                               where (user.Id == userId && like.IsShown == false && like.LikedOrDisliked == true)
                               select new DtoGetLikes
                               {
                                   Username = us.Username,
                                   MarketName = market.Name,
                                   MarketSeoUrl = market.SeoUrl,
                                   Comment = comment.Message.Substring(0, Math.Min(comment.Message.Length, 50))
                               }).Take(10).ToListAsync();
            return query;
            
        }

        //public async Task<List<DtoGetDislikes>> GetDislikeNotifications(int userId)
        //{
        //    var query = await(from like in _context.CommentLikes
        //                      join comment in _context.Comments on like.CommentId equals comment.Id
        //                      join user in _context.Users on comment.UserId equals user.Id
        //                      join us in _context.Users on like.UserId equals us.Id
        //                      join market in _context.Markets on comment.MarketId equals market.Id
        //                      where (user.Id == userId && like.IsShown == false && like.LikedOrDisliked == false)
        //                      select new DtoGetDislikes
        //                      {
        //                          Username = us.Username,
        //                          MarketName = market.Name,
        //                          MarketSeoUrl = market.SeoUrl,
        //                          Comment = comment.Message.Substring(0, Math.Min(comment.Message.Length, 50))
        //                      }).Take(10).ToListAsync();
        //    return query;
        //}

        /// <summary>
        /// UserId'si verilen kullanıcının CommentLike Entry'lerini döndürür.
        /// </summary>
        /// <param name="userId">Yorum sahibinin UserId'si</param>
        /// <returns></returns>
        public async Task<List<DtoLikeOrDislike>> GetCommentLikeEntries(int userId)
        {
            var query = await (from likes in _context.CommentLikes
                               join comment in _context.Comments on likes.CommentId equals comment.Id
                               where (userId == comment.UserId && likes.LikedOrDisliked == true && likes.IsShown == false)
                               select new DtoLikeOrDislike
                               {
                                   CommentId = likes.CommentId,
                                   UserId = likes.UserId,
                                   Id = likes.Id,
                                   LikedDateTime = likes.LikedDateTime,
                                   LikeOrDislike = likes.LikedOrDisliked
                               }).Take(10).ToListAsync();
            return query;
        }

        //public async Task<List<DtoLikeOrDislike>> GetCommentDislikeEntries(int userId)
        //{
        //    var query = await (from likes in _context.CommentLikes
        //                       join comment in _context.Comments on likes.CommentId equals comment.Id
        //                       where (userId == comment.UserId && likes.LikedOrDisliked == false && likes.IsShown == false)
        //                       select new DtoLikeOrDislike
        //                       {
        //                           CommentId = likes.CommentId,
        //                           UserId = likes.UserId,
        //                           Id = likes.Id,
        //                           LikedDateTime = likes.LikedDateTime,
        //                           LikeOrDislike = likes.LikedOrDisliked
        //                       }).Take(10).ToListAsync();
        //    return query;
        //}
    }
}
