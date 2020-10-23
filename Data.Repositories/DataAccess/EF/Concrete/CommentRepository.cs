using Common.Model.Comment.Dto;
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
    public class CommentRepository : EntityRepositoryBase<Comments>, ICommentRepository
    {
        private readonly EFDBContext _context;
        public CommentRepository(EFDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        #region YorumSayılarınıDöndürenMetotlar

        /// <summary>
        /// Tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <returns>Verilen marketId'ye ait tüm yorumların sayısını döndürür.</returns>
        public async Task<int> GetAllCommentCounts(int marketId)
        {
            int tumYorumlar = await (from comment in _context.Comments
                                     where (marketId == comment.MarketId && comment.IsDelete == false)
                                     select comment.Id).CountAsync();
            return tumYorumlar;
        }

        /// <summary>
        /// Birbirini bloklayan kullanıcıların yorumlarını saymayarak tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen marketId'ye ait tüm yorumların sayısını döndürür.</returns>
        public async Task<int> GetAllCommentCounts(int marketId, int? userId)
        {
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();

            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            int tumYorumlar = await (from comment in _context.Comments
                                     where (marketId == comment.MarketId && comment.IsDelete == false && blokListesi.Contains(comment.UserId) == false)
                                     select comment.Id).CountAsync();
            return tumYorumlar;
        }

        /// <summary>
        /// Grafikli anketler hariç, grafik içeren tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <returns>Verilen marketId'ye ait grafik içeren yorumların sayısını döndürür.</returns>
        public async Task<int> GetGraphicCommentCounts(int marketId)
        {
            var grafikSayisi = await (from gcom in _context.CommentGraphics
                                      join comment in _context.Comments on gcom.CommentId equals comment.Id
                                      join poll in _context.CommentPolls on comment.Id equals poll.CommentId into cp
                                      from cpls in cp.DefaultIfEmpty()
                                      where (gcom.CommentId != cpls.CommentId && marketId == comment.MarketId && comment.IsDelete == false)
                                      select gcom.CommentId).CountAsync();
            return grafikSayisi;
        }

        /// <summary>
        /// Birbirini bloklayan kullanıcıların yorumlarını ve grafikli anketleri saymayarak grafik içeren yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen marketId'ye ait grafik içeren yorumların sayısını döndürür.</returns>
        public async Task<int> GetGraphicCommentCounts(int marketId, int? userId)
        {
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();

            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            var grafikSayisi = await (from gcom in _context.CommentGraphics
                                      join comment in _context.Comments on gcom.CommentId equals comment.Id
                                      join poll in _context.CommentPolls on comment.Id equals poll.CommentId into cp
                                      from cpls in cp.DefaultIfEmpty()
                                      where (gcom.CommentId != cpls.CommentId && marketId == comment.MarketId && comment.IsDelete == false && blokListesi.Contains(comment.UserId) == false)
                                      select gcom.CommentId).CountAsync();
            return grafikSayisi;
        }

        /// <summary>
        /// Anket içeren tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <returns>Verilen marketId'ye ait anket içeren yorumların sayısını döndürür.</returns>
        public async Task<int> GetOnlyPollCounts(int marketId)
        {
            var anketSayisi = await (from pcom in _context.CommentPolls
                                     join comment in _context.Comments on pcom.CommentId equals comment.Id
                                     where (comment.IsDelete == false && marketId == comment.MarketId)
                                     select pcom.Id).CountAsync();
            return anketSayisi;
        }

        /// <summary>
        /// Birbirini bloklayan kullanıcıların anketlerini saymayarak anket içeren yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen marketId'ye ait anket içeren yorumların sayısını döndürür.</returns>
        public async Task<int> GetOnlyPollCounts(int marketId, int? userId)
        {
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();

            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            var anketSayisi = await (from pcom in _context.CommentPolls
                                     join comment in _context.Comments on pcom.CommentId equals comment.Id
                                     where (marketId == comment.MarketId && comment.IsDelete == false && blokListesi.Contains(comment.UserId) == false)
                                     select pcom.CommentId).CountAsync();
            return anketSayisi;
        }

        /// <summary>
        /// Sadece yıldızlı kullanıcılara ait tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <returns>Verilen marketId'ye ait sadece yıldızlı kullanıcıların yorum sayısını döndürür.</returns>
        public async Task<int> GetOnlyStarredCommentCounts(int marketId)
        {
            var yildizliYorum = await (from comment in _context.Comments
                                       join userprofile in _context.UserProfiles on comment.UserId equals userprofile.Id
                                       where (marketId == comment.MarketId && userprofile.UserLevel != 0 && comment.IsDelete == false)
                                       select comment.Id).CountAsync();
            return yildizliYorum;
        }

        /// <summary>
        /// Birbirini bloklayan kullanıcıların yorumlarını saymayarak sadece yıldızlı kullanıcılara ait tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen marketId'ye ait sadece yıldızlı kullanıcıların yorum sayısını döndürür.</returns>
        public async Task<int> GetOnlyStarredCommentCounts(int marketId, int? userId)
        {
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();

            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            var yildizliYorum = await (from comment in _context.Comments
                                       join userprofile in _context.UserProfiles on comment.UserId equals userprofile.Id
                                       where (blokListesi.Contains(comment.UserId) == false && marketId == comment.MarketId && userprofile.UserLevel != 0 && comment.IsDelete == false)
                                       select comment.Id).CountAsync();
            return yildizliYorum;
        }

        /// <summary>
        /// Online olan kullanıcının takip ettiği userlara ait tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="marketId">MarketId</param>
        /// <param name="userId">MarketId</param>
        /// <returns>Verilen marketId'ye ait sadece takip edilen kullanıcıların yorum sayısını döndürür.</returns>
        public async Task<int> GetOnlySubscribedUserCommentCounts(int marketId, int? userId)
        {
            var takipEttiklerim = await (from subscribe in _context.Subscriptions
                                         where subscribe.SubscribedByUserId == userId
                                         select subscribe.SubscribedUserId).ToListAsync();

            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();

            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            var query = await (from comment in _context.Comments
                               where (marketId == comment.MarketId && comment.IsDelete == false && takipEttiklerim.Contains(comment.UserId) && blokListesi.Contains(comment.UserId) == false)
                               select comment.Id).CountAsync();
            return query;
        }

        /// <summary>
        /// Belirli bir ankete cevap olarak yazılmış tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="commentId">Anketin id'si</param>
        /// <returns>Verilen commentId'ye cevap olarak yazılmış yorumların sayısını döndürür.</returns>
        public async Task<int> GetPollResponseCounts(int commentId)
        {
            int commentResponseCount = await (from comment in _context.Comments
                                              where (commentId == comment.CommentParentId && comment.IsDelete == false)
                                              select comment.Id).CountAsync();
            return commentResponseCount;
        }

        /// <summary>
        /// Birbirini bloklayan kullanıcıların yorumlarını saymayarak belirli bir ankete cevap olarak yazılmış tüm yorumların sayısını verir.
        /// </summary>
        /// <param name="commentId">Anketin id'si</param>
        /// <param name="userId">UserId</param>
        /// <returns>Verilen commentId'ye cevap olarak yazılmış yorumların sayısını döndürür.</returns>
        public async Task<int> GetPollResponseCounts(int commentId, int? userId)
        {
            //Login olmuş userId'nin blokladığı kullanıcılar bulunuyor.
            var blockedUsers = await (from blocks in _context.Blocks
                                      where blocks.BlockedByUserId == userId
                                      select blocks.BlockedUserId).ToListAsync();
            //Login olmuş userId'yi bloklayan kullanıcılar bulunuyor.
            var blockedByUsers = await (from block in _context.Blocks
                                        where block.BlockedUserId == userId
                                        select block.BlockedByUserId).ToListAsync();

            //Üstteki 2 sonuç kümesi UNION ile birleştiriliyor.
            var blockList = blockedUsers.Union(blockedByUsers);

            int commentResponseCount = await (from comment in _context.Comments
                                              where (blockList.Contains(comment.UserId) == false && commentId == comment.CommentParentId && comment.IsDelete == false)
                                              select comment.Id).CountAsync();
            return commentResponseCount;
        }

        #endregion

        #region YorumlarınBeğeniSayılarınınDöndürenMetotlar

        /// <summary>
        /// Gelen CommentId'ye göre yorumun beğeni sayısını döndürür.
        /// </summary>
        /// <param name="commentId">Yorumun Id'si</param>
        /// <returns>int tipte yorumun kaç kere beğenildiğini döndürür.</returns>
        public async Task<int> CommentLikeCount(int commentId)
        {
            var query = await (from commentlike in _context.CommentLikes
                               where (commentId == commentlike.CommentId && commentlike.LikedOrDisliked == true)
                               select commentlike.LikedOrDisliked).CountAsync();
            return query;
        }

        /// <summary>
        /// Gelen CommentId'ye göre yorumun beğenmeme sayısını döndürür.
        /// </summary>
        /// <param name="commentId">Yorumun Id'si</param>
        /// <returns>int tipte yorumun kaç kere beğenilmediğini döndürür.</returns>
        public async Task<int> CommentDislikeCount(int commentId)
        {
            var query = await (from commentlike in _context.CommentLikes
                               where (commentId == commentlike.CommentId && commentlike.LikedOrDisliked == false)
                               select commentlike.LikedOrDisliked).CountAsync();
            return query;
        }

        #endregion

        #region TümYorumlarıGetir

        /// <summary>
        /// Giriş yapmamış misafir kullanıcılar için ilgili currency'deki silinmiş yorumlar hariç tüm yorumları (düz yorum, anket ve grafikli) getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        public async Task<List<DtoGetComments>> GetAllComments(int rowCount, int marketId, int startPage)
        {
            //LINQ Düz Yazım
            var query = await (from comment in _context.Comments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (marketId == comment.MarketId && comment.IsDelete == false)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollStartDate = cp.StartDate,
                                   PollEndDate = cp.EndDate
                                   //TODO: Eğer anket ve grafikli olanlar doluysa parent dönülmeyecek. 
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        public async Task<List<DtoGetComments>> GetAllComments(int rowCount, int marketId, int? userId, int startPage)
        {
            //Login olmuş userId'nin blokladığı kullanıcılar bulunuyor.
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();
            //Login olmuş userId'yi bloklayan kullanıcılar bulunuyor.
            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            //Üstteki 2 sonuç kümesi UNION ile birleştiriliyor.
            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            //Birbirlerini bloklayan kullanıcıların birbirlerinin yorumlarını görmemesi sağlanıyor.
            var query = await (from comment in _context.Comments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (blokListesi.Contains(comment.UserId) == false && marketId == comment.MarketId && comment.IsDelete == false)
                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollStartDate = cp.StartDate,
                                   PollEndDate = cp.EndDate
                               }).Skip(startPage).Take(rowCount).ToListAsync();

            return query;
        }

        #endregion

        #region GrafikİçerenYorumlarıGetir

        /// <summary>
        /// Giriş yapmamış misafir kullanıcılar için ilgili market'teki silinmiş yorumlar hariç sadece grafikli yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        public async Task<List<DtoGetComments>> GetOnlyGraphicComments(int rowCount, int marketId, int startPage)
        {
            var query = await (from comment in _context.Comments
                               join graphic in _context.CommentGraphics on comment.Id equals graphic.CommentId
                               join poll in _context.CommentPolls on comment.Id equals poll.CommentId into cp
                               from cpls in cp.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (marketId == comment.MarketId && comment.IsDelete == false && graphic.CommentId != cpls.CommentId)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   UserLevel = userprofile.UserLevel,
                                   Graphic = graphic.GraphicPath
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek sadece grafik içeren yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        public async Task<List<DtoGetComments>> GetOnlyGraphicComments(int rowCount, int marketId, int? userId, int startPage)
        {
            //Login olmuş userId'nin blokladığı kullanıcılar bulunuyor.
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();
            //Login olmuş userId'yi bloklayan kullanıcılar bulunuyor.
            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            //Üstteki 2 sonuç kümesi UNION ile birleştiriliyor.
            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            var query = await (from comment in _context.Comments
                               join graphic in _context.CommentGraphics on comment.Id equals graphic.CommentId
                               join poll in _context.CommentPolls on comment.Id equals poll.CommentId into cp
                               from cpls in cp.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (blokListesi.Contains(comment.UserId) == false && marketId == comment.MarketId && comment.IsDelete == false && graphic.CommentId != cpls.CommentId)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   UserLevel = userprofile.UserLevel,
                                   Graphic = graphic.GraphicPath
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }

        #endregion

        #region AnketleriGetir

        /// <summary>
        /// Giriş yapmamış kullanıcılar için ilgili market'teki silinmiş yorumlar hariç sadece anket içeren yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        public async Task<List<DtoGetComments>> GetOnlyPolls(int rowCount, int marketId, int startPage)
        {
            var query = await (from poll in _context.Comments
                               join curpoll in _context.CommentPolls on poll.Id equals curpoll.CommentId
                               //Anketlerde grafik olma zorunluluğu olmadığından dolayı left join kullandım. Inner join yaparsak tam eşleşen kayıtları getiriyor. Yani graphic pathi dolu olanları getirir.
                               join pollgraph in _context.CommentGraphics on poll.Id equals pollgraph.CommentId into cg
                               from cpg in cg.DefaultIfEmpty()
                               join user in _context.Users on poll.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (poll.IsDelete == false && marketId == poll.MarketId)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby poll.CreatedDateTime descending
                               orderby poll.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = poll.Id,
                                   MarketId = poll.MarketId,
                                   Username = user.Username,
                                   UserId = poll.UserId,
                                   DateTime = poll.CreatedDateTime,
                                   PollId = curpoll.Id,
                                   Graphic = cpg.GraphicPath,
                                   Message = poll.Message,
                                   PollStartDate = curpoll.StartDate,
                                   PollEndDate = curpoll.EndDate,
                                   AvatarPath = userprofile.AvatarPath,
                                   UserLevel = userprofile.UserLevel
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek sadece anket içeren yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        public async Task<List<DtoGetComments>> GetOnlyPolls(int rowCount, int marketId, int? userId, int startPage)
        {
            //Login olmuş userId'nin blokladığı kullanıcılar bulunuyor.
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();
            //Login olmuş userId'yi bloklayan kullanıcılar bulunuyor.
            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            //Üstteki 2 sonuç kümesi UNION ile birleştiriliyor.
            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            var query = await (from poll in _context.Comments
                               join curpoll in _context.CommentPolls on poll.Id equals curpoll.CommentId
                               //Anketlerde grafik olma zorunluluğu olmadığından dolayı left join kullandım. Inner join yaparsak tam eşleşen kayıtları getiriyor. Yani graphic pathi dolu olanları getirir.
                               join pollgraph in _context.CommentGraphics on poll.Id equals pollgraph.CommentId into cg
                               from cpg in cg.DefaultIfEmpty()
                               join user in _context.Users on poll.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (blokListesi.Contains(poll.UserId) == false && poll.IsDelete == false && marketId == poll.MarketId)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby poll.CreatedDateTime descending
                               orderby poll.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = poll.Id,
                                   MarketId = poll.MarketId,
                                   Username = user.Username,
                                   UserId = poll.UserId,
                                   DateTime = poll.CreatedDateTime,
                                   PollId = curpoll.Id,
                                   Graphic = cpg.GraphicPath,
                                   Message = poll.Message,
                                   PollStartDate = curpoll.StartDate,
                                   PollEndDate = curpoll.EndDate,
                                   AvatarPath = userprofile.AvatarPath,
                                   UserLevel = userprofile.UserLevel
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }

        #endregion

        #region YıldızlıKullanıcılarınYorumlarınıGetir

        /// <summary>
        /// Giriş yapmamış kullanıcılar için ilgili market'teki silinmiş yorumlar hariç yıldızlı kullanıcıların karışık yorumlarını getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        public async Task<List<DtoGetComments>> GetOnlyStarredUserComments(int rowCount, int marketId, int startPage)
        {
            var query = await (from comment in _context.Comments
                                   //Left Join -- CurrencyGraphicComments --> CurrencyComments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId into cgh
                               from cg in cgh.DefaultIfEmpty()
                                   //Left Join -- CurrencyPolls --> CurrencyComments
                               join currencypoll in _context.CommentPolls on comment.Id equals currencypoll.CommentId into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (marketId == comment.MarketId && userprofile.UserLevel != 0 && comment.IsDelete == false)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   Graphic = cg.GraphicPath,
                                   PollId = cp.Id,
                                   PollEndDate = cp.EndDate,
                                   PollStartDate = cp.StartDate,
                                   UserLevel = userprofile.UserLevel,
                                   AvatarPath = userprofile.AvatarPath
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek yıldızlı kullanıcıların karışık yorumlarını getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        public async Task<List<DtoGetComments>> GetOnlyStarredUserComments(int rowCount, int marketId, int? userId, int startPage)
        {
            //Login olmuş userId'nin blokladığı kullanıcılar bulunuyor.
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();
            //Login olmuş userId'yi bloklayan kullanıcılar bulunuyor.
            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            //Üstteki 2 sonuç kümesi UNION ile birleştiriliyor.
            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            //Birbirlerini bloklayan kullanıcıların birbirlerinin yorumlarını görmemesi sağlanıyor.
            var query = await (from comment in _context.Comments
                                   //Left Join -- CurrencyGraphicComments --> CurrencyComments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId into cgh
                               from cg in cgh.DefaultIfEmpty()
                                   //Left Join -- CurrencyPolls --> CurrencyComments
                               join currencypoll in _context.CommentPolls on comment.Id equals currencypoll.CommentId into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (blokListesi.Contains(comment.UserId) == false && marketId == comment.MarketId && userprofile.UserLevel != 0 && comment.IsDelete == false)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   Graphic = cg.GraphicPath,
                                   PollId = cp.Id,
                                   PollEndDate = cp.EndDate,
                                   PollStartDate = cp.StartDate,
                                   UserLevel = userprofile.UserLevel,
                                   AvatarPath = userprofile.AvatarPath
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }

        #endregion

        #region TakipEttiğimKullanıcılarınYorumları

        /// <summary>
        /// Login olmuş kullanıcılar için ilgili market'teki silinmiş yorumlar hariç ve birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek takip ettiğim kullanıcıların kullanıcıların karışık yorumlarını getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="currencyId">CurrencyId parametre currency id'sine göre o currency'e ait yorumlar için kullanılır.</param>
        /// <param name="userId">Login olmuş kullanıcının Id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir yorum listesi döndürür.</returns>
        public async Task<List<DtoGetComments>> GetOnlySubscribedUserComments(int rowCount, int marketId, int? userId, int startPage)
        {
            var takipEttiklerim = await (from subscribe in _context.Subscriptions
                                         where subscribe.SubscribedByUserId == userId
                                         select subscribe.SubscribedUserId).ToListAsync();

            //Login olmuş userId'nin blokladığı kullanıcılar bulunuyor.
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();
            //Login olmuş userId'yi bloklayan kullanıcılar bulunuyor.
            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            //Üstteki 2 sonuç kümesi UNION ile birleştiriliyor.
            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            var query = await (from comment in _context.Comments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (marketId == comment.MarketId && comment.IsDelete == false && takipEttiklerim.Contains(comment.UserId) && blokListesi.Contains(comment.UserId) == false)
                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollStartDate = cp.StartDate,
                                   PollEndDate = cp.EndDate
                               }).Skip(startPage).Take(rowCount).ToListAsync();

            return query;
        }

        #endregion

        #region AnketVeyaGrafiğeYapılanYorumlar

        /// <summary>
        /// Giriş yapmamış kullanıcılar için commentidye göre o ankete ait yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="commentId">Anketin id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir ankete ait yorum listesini döndürür.</returns>
        public async Task<List<DtoGetComments>> GetGraphicOrPollReplies(int commentId)
        {
            var query = await (from comment in _context.Comments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               join market in _context.Markets on comment.MarketId equals market.Id
                               where (commentId == comment.CommentParentId && comment.IsDelete == false)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   MarketName = market.Name,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollStartDate = cp.StartDate,
                                   PollEndDate = cp.EndDate,
                                   CommentParentId = comment.CommentParentId
                               }).ToListAsync();
            return query;
        }

        /// <summary>
        /// Login olmuş kullanıcılar için birbirini bloklayan kullanıcıların karşılıklı olarak göstermeyerek commentidye göre o ankete ait yorumları getirir.
        /// </summary>
        /// <param name="rowCount">RowCount parametresi bir sayfada kaç yorum gösterileceğini belirtir.</param>
        /// <param name="commentId">Anketin id'sini belirtir.</param>
        /// <param name="userId">Login olan kullanıcının id'sini belirtir.</param>
        /// <param name="startPage">StartPage parametresi ise kaçıncı sayfada olduğunu belirtir.</param>
        /// <returns>Bu metod geriye DTOGetComments tipinde bir ankete ait yorum listesini döndürür.</returns>
        public async Task<List<DtoGetComments>> GetGraphicOrPollReplies(int commentId, int? userId)
        {
            //Login olmuş userId'nin blokladığı kullanıcılar bulunuyor.
            var blockedUsers = await (from blocks in _context.Blocks
                                      where blocks.BlockedByUserId == userId
                                      select blocks.BlockedUserId).ToListAsync();
            //Login olmuş userId'yi bloklayan kullanıcılar bulunuyor.
            var blockedByUsers = await (from block in _context.Blocks
                                        where block.BlockedUserId == userId
                                        select block.BlockedByUserId).ToListAsync();

            //Üstteki 2 sonuç kümesi UNION ile birleştiriliyor.
            var blockList = blockedUsers.Union(blockedByUsers);

            var query = await (from comment in _context.Comments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               join market in _context.Markets on comment.MarketId equals market.Id
                               where (blockList.Contains(comment.UserId) == false && commentId == comment.CommentParentId && comment.IsDelete == false)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   MarketName = market.Name,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollStartDate = cp.StartDate,
                                   PollEndDate = cp.EndDate,
                                   CommentParentId = comment.CommentParentId
                               }).ToListAsync();
            return query;
        }

        #endregion

        //TODO: GetUsername kullanılacak. username getirilirken TümYorumlarıGetir managerındaki gibi.
        //todo: aykut buraya gerek yok gibi son yoruları getiren method var zaten eklemeden sonra bunu kullanıyorsan iptal bunun yerine son yorumları getiren method kullanılacak
        /// <summary>
        /// Gelen commentId'ye göre o comment'ı döndürür.
        /// </summary>
        /// <param name="commentId">Yorumun Id'si</param>
        /// <returns>DTOGetComments tipinde tek yorum döndürür.</returns>
        public async Task<DtoGetComments> GetComment(int commentId)
        {
            var query = await (from comment in _context.Comments
                                   //Yeni eklendi market name döndürmek için.
                               join markets in _context.Markets on comment.MarketId equals markets.Id
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (commentId == comment.Id)

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   //CommentParentId = comment.CommentParentId,
                                   DateTime = comment.CreatedDateTime,
                                   MarketId = comment.MarketId,
                                   MarketName = markets.Name,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   Message = comment.Message,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollEndDate = cp.EndDate,
                                   PollStartDate = cp.StartDate,
                                   //ParentUsername = (from comments in _context.Comments
                                   //                  join user in _context.Users on comments.UserId equals user.Id
                                   //                  where (comments.Id == comment.CommentParentId)
                                   //                  select user.Username).SingleOrDefault()
                               }).SingleOrDefaultAsync();
            return query;
        }

        /// <summary>
        /// Gelen commentId'ye göre o comment'ı döndürür. Blok mevzusuna bakarak.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoGetComments> GetComment(int commentId, int userId)
        {
            //Login olmuş userId'nin blokladığı kullanıcılar bulunuyor.
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();
            //Login olmuş userId'yi bloklayan kullanıcılar bulunuyor.
            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            //Üstteki 2 sonuç kümesi UNION ile birleştiriliyor.
            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            var query = await (from comment in _context.Comments
                               //Yeni eklendi market name döndürmek için.
                               join markets in _context.Markets on comment.MarketId equals markets.Id
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (blokListesi.Contains(comment.UserId) == false && commentId == comment.Id)
                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   //CommentParentId = comment.CommentParentId,
                                   DateTime = comment.CreatedDateTime,
                                   MarketId = comment.MarketId,
                                   MarketName = markets.Name,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   Message = comment.Message,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollEndDate = cp.EndDate,
                                   PollStartDate = cp.StartDate,
                                   //ParentUsername = (from comments in _context.Comments
                                   //                  join user in _context.Users on comments.UserId equals user.Id
                                   //                  where (comments.Id == comment.CommentParentId)
                                   //                  select user.Username).SingleOrDefault()
                               }).SingleOrDefaultAsync();
            return query;
        }

        /// <summary>
        /// Verilen commentId'nin sahibinin username'ini bulur.
        /// </summary>
        /// <param name="commentId">CommentParentId</param>
        /// <returns>Username döner.</returns>
        public async Task<string> GetUsername(int? commentId)
        {
            var query = await (from comments in _context.Comments
                               join user in _context.Users on comments.UserId equals user.Id
                               where (commentId == comments.Id)
                               select user.Username).SingleOrDefaultAsync();
            return query;
        }

        /// <summary>
        /// Verilen CommentId'nin commentParentId parametresini bulur.
        /// </summary>
        /// <param name="commentId">Yorumun id'si</param>
        /// <returns>CommentId'ye göre CommentParentId'sini döndürür.</returns>
        public async Task<int?> GetParentId(int commentId)
        {
            var query = await (from comment in _context.Comments
                               where (commentId == comment.Id)
                               select comment.CommentParentId).SingleOrDefaultAsync();
            return query;
        }

        /// <summary>
        /// Online kullanıcı ankete oy kullanıp kullanmadığını bulur.
        /// </summary>
        /// <param name="userId">Online olan kullanıcının id'si</param>
        /// <param name="pollId">Anketin id'si</param>
        /// <returns>Kullanıcının hangi seçeneğe oy verdiği yani pollOptionId döner.</returns>
        public async Task<int> GetUserPollVote(int? userId, int? pollId)
        {
            var query = await (from vote in _context.CommentPollVotes
                               join option in _context.CommentPollOptions on vote.PollOptionId equals option.Id
                               join poll in _context.CommentPolls on option.PollId equals poll.Id
                               where (userId == vote.UserId && pollId == poll.Id)
                               select vote.PollOptionId
                               ).FirstOrDefaultAsync();
            return query;
        }

        /// <summary>
        /// İlgili ankete yapılan toplam oy sayısı verir.
        /// </summary>
        /// <param name="pollOptionId">Anketin seçeneğini belirtir.</param>
        /// <returns>Verilen anket seçeneğinin sayısını döndürür.</returns>
        public async Task<int> TotalVoteCount(int pollOptionId)
        {
            var query = await (from pollvotes in _context.CommentPollVotes
                               where (pollOptionId == pollvotes.PollOptionId)
                               select pollvotes.Id).CountAsync();
            return query;
        }

        /// <summary>
        /// İlgili anketin anket seçenekleri, seçeneklerin idleri, ve her bir seçeneğin oy sayısını döndürür.
        /// </summary>
        /// <param name="pollId">Anketin Id'si</param>
        /// <returns>DTOPollOptions tipinde anketin seçeneklerini liste şeklinde döndürür.</returns>
        public async Task<List<DtoPollOptions>> GetPollOptions(int? pollId)
        {
            var query = await (from polloptions in _context.CommentPollOptions
                               join poll in _context.CommentPolls on polloptions.PollId equals poll.Id
                               where (pollId == polloptions.PollId)
                               select new DtoPollOptions
                               {
                                   Option = polloptions.Options,
                                   OptionId = polloptions.Id,
                                   Vote = (from votes in _context.CommentPollVotes
                                           where polloptions.Id == votes.PollOptionId
                                           select votes.PollOptionId).Count()
                               }).ToListAsync();
            return query;
        }

        //User Profile sayfasındaki kullanıcının grafik, anket, beğenilen ve tüm yorumlarının sorguları.
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
            var query = await (from comment in _context.Comments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               join market in _context.Markets on comment.MarketId equals market.Id
                               where userId == comment.UserId && comment.IsDelete == false

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   MarketName = market.Name,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollStartDate = cp.StartDate,
                                   PollEndDate = cp.EndDate
                                   //TODO: Eğer anket ve grafikli olanlar doluysa parent dönülmeyecek. 
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }
        /// <summary>
        /// User Profil sayfası için profil sahibinin tüm yorumlarının saysını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetAllUserCommentCount(int userId)
        {
            int query = await (from comment in _context.Comments
                               where (userId == comment.UserId && comment.IsDelete == false)
                               select comment.Id).CountAsync();
            return query;
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
            var query = await (from comment in _context.Comments
                               join graphic in _context.CommentGraphics on comment.Id equals graphic.CommentId
                               join poll in _context.CommentPolls on comment.Id equals poll.CommentId into cp
                               from cpls in cp.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               join market in _context.Markets on comment.MarketId equals market.Id
                               where (userId == comment.UserId && comment.IsDelete == false && graphic.CommentId != cpls.CommentId)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   MarketName = market.Name,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   UserLevel = userprofile.UserLevel,
                                   Graphic = graphic.GraphicPath
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }

        /// <summary>
        /// User Profil sayfası için profil sahibinin grafik içeren yorumlarının sayısını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetUserGraphicCommentCount(int userId)
        {
            var query = await (from gcom in _context.CommentGraphics
                               join comment in _context.Comments on gcom.CommentId equals comment.Id
                               join poll in _context.CommentPolls on comment.Id equals poll.CommentId into cp
                               from cpls in cp.DefaultIfEmpty()
                               where (gcom.CommentId != cpls.CommentId && userId == comment.UserId && comment.IsDelete == false)
                               select gcom.CommentId).CountAsync();
            return query;
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
            var query = await (from comment in _context.Comments
                               join curpoll in _context.CommentPolls on comment.Id equals curpoll.CommentId
                               //Anketlerde grafik olma zorunluluğu olmadığından dolayı left join kullandım. Inner join yaparsak tam eşleşen kayıtları getiriyor. Yani graphic pathi dolu olanları getirir.
                               join pollgraph in _context.CommentGraphics on comment.Id equals pollgraph.CommentId into cg
                               from cpg in cg.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               join market in _context.Markets on comment.MarketId equals market.Id
                               where (comment.IsDelete == false && userId == comment.UserId)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   MarketName = market.Name,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   PollId = curpoll.Id,
                                   Graphic = cpg.GraphicPath,
                                   Message = comment.Message,
                                   PollStartDate = curpoll.StartDate,
                                   PollEndDate = curpoll.EndDate,
                                   AvatarPath = userprofile.AvatarPath,
                                   UserLevel = userprofile.UserLevel
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }
        /// <summary>
        /// User Profil sayfası için profil sahibinin anket içeren yorumlarının sayısını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetUserPollCount(int userId)
        {
            var query = await (from pcom in _context.CommentPolls
                               join comment in _context.Comments on pcom.CommentId equals comment.Id
                               where (comment.IsDelete == false && userId == comment.UserId)
                               select pcom.Id).CountAsync();
            return query;
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
            var query = await (from comment in _context.Comments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               join market in _context.Markets on comment.MarketId equals market.Id
                               join commentlikes in _context.CommentLikes on comment.Id equals commentlikes.CommentId
                               where userId == comment.UserId && comment.IsDelete == false && commentlikes.LikedOrDisliked == true

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   MarketName = market.Name,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollStartDate = cp.StartDate,
                                   PollEndDate = cp.EndDate
                                   //TODO: Eğer anket ve grafikli olanlar doluysa parent dönülmeyecek. 
                               }).Skip(startPage).Take(rowCount).ToListAsync();
            return query;
        }

        /// <summary>
        /// User Profil sayfası için profil sahibinin beğenilen yorumlarının sayısını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetUserLikedCount(int userId)
        {
            int query = await (from comment in _context.Comments
                               join commentlikes in _context.CommentLikes on comment.Id equals commentlikes.CommentId
                               where (userId == comment.UserId && comment.IsDelete == false && commentlikes.LikedOrDisliked == true)
                               select comment.Id).CountAsync();
            return query;
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
            var query = await (from comment in _context.Comments
                               join curpoll in _context.CommentPolls on comment.Id equals curpoll.CommentId
                               into cp
                               from cpo in cp.DefaultIfEmpty()
                                   //Anketlerde grafik olma zorunluluğu olmadığından dolayı left join kullandım. Inner join yaparsak tam eşleşen kayıtları getiriyor. Yani graphic pathi dolu olanları getirir.
                               join pollgraph in _context.CommentGraphics on comment.Id equals pollgraph.CommentId into cg
                               from cpg in cg.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               join market in _context.Markets on comment.MarketId equals market.Id

                               where comment.IsDelete == false && commentId == comment.Id

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   MarketName = market.Name,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   PollId = cpo.Id,
                                   Graphic = cpg.GraphicPath,
                                   Message = comment.Message,
                                   PollStartDate = cpo.StartDate,
                                   PollEndDate = cpo.EndDate,
                                   AvatarPath = userprofile.AvatarPath,
                                   UserLevel = userprofile.UserLevel
                               }).FirstOrDefaultAsync();
            return query;
        }

        //Message'ı verilen yorumun id sini döndürür.
        public async Task<int> GetCommentId(int pollId)
        {
            var query = await (from comment in _context.Comments
                               join poll in _context.CommentPolls on comment.Id equals poll.CommentId
                               where pollId == poll.Id
                               select comment.Id).FirstOrDefaultAsync();
            return query;
        }

        //CommentId'si verilen anketin PollId'sini döndürür.
        public async Task<int> GetPollId(int commentId)
        {
            var query = await (from commentpoll in _context.CommentPolls
                               where commentId == commentpoll.CommentId
                               select commentpoll.Id).FirstOrDefaultAsync();
            return query;
        }

        /// <summary>
        /// Verilen commentId'den sonra eklenen yorumları getirir.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public async Task<List<DtoGetComments>> GetAllAfterReply(int lastViewCommentId, int userId, int marketId)
        {
            //Login olmuş userId'nin blokladığı kullanıcılar bulunuyor.
            var kullanicininBlokladiklari = await (from blocks in _context.Blocks
                                                   where blocks.BlockedByUserId == userId
                                                   select blocks.BlockedUserId).ToListAsync();
            //Login olmuş userId'yi bloklayan kullanıcılar bulunuyor.
            var kullaniciyiBloklayanlar = await (from block in _context.Blocks
                                                 where block.BlockedUserId == userId
                                                 select block.BlockedByUserId).ToListAsync();

            //Üstteki 2 sonuç kümesi UNION ile birleştiriliyor.
            var blokListesi = kullanicininBlokladiklari.Union(kullaniciyiBloklayanlar);

            var query = await (from comment in _context.Comments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (blokListesi.Contains(comment.UserId) == false && marketId == comment.MarketId && comment.Id > lastViewCommentId && comment.IsDelete == false)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollStartDate = cp.StartDate,
                                   PollEndDate = cp.EndDate
                                   //TODO: Eğer anket ve grafikli olanlar doluysa parent dönülmeyecek. 
                               }).ToListAsync();
            return query;
        }

        /// <summary>
        /// Verilen commentId'den sonra eklenen yorumları getirir.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="marketId"></param>
        /// <returns></returns>
        public async Task<List<DtoGetComments>> GetAllAfterReply(int lastViewCommentId, int marketId)
        {
            var query = await (from comment in _context.Comments
                               join currencygraphic in _context.CommentGraphics on comment.Id equals currencygraphic.CommentId
                               into cgh
                               from cg in cgh.DefaultIfEmpty()
                               join commentpoll in _context.CommentPolls on comment.Id equals commentpoll.CommentId
                               into cpl
                               from cp in cpl.DefaultIfEmpty()
                               join user in _context.Users on comment.UserId equals user.Id
                               join userprofile in _context.UserProfiles on user.Id equals userprofile.UserId
                               where (marketId == comment.MarketId && comment.Id > lastViewCommentId && comment.IsDelete == false)

                               //Todo:Mysql için tam ters sıralama mantığı var
                               orderby comment.CreatedDateTime descending
                               orderby comment.IsPinned descending

                               select new DtoGetComments
                               {
                                   Id = comment.Id,
                                   MarketId = comment.MarketId,
                                   Username = user.Username,
                                   UserId = comment.UserId,
                                   DateTime = comment.CreatedDateTime,
                                   Message = comment.Message,
                                   AvatarPath = userprofile.AvatarPath,
                                   Graphic = cg.GraphicPath,
                                   UserLevel = userprofile.UserLevel,
                                   PollId = cp.Id,
                                   PollStartDate = cp.StartDate,
                                   PollEndDate = cp.EndDate
                                   //TODO: Eğer anket ve grafikli olanlar doluysa parent dönülmeyecek. 
                               }).ToListAsync();
            return query;
        }

        public async Task<string> GetMessage(int commentId)
        {
            var query = await (from comments in _context.Comments
                               where commentId == comments.Id
                               select comments.Message).FirstOrDefaultAsync();
            return query;
        }
    }
}
