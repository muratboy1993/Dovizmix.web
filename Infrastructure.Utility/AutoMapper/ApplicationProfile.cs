using AutoMapper;
using Common.Model.BannedUser.Dto;
using Common.Model.BannedUser.Request;
using Common.Model.Block.Dto;
using Common.Model.Block.Request;
using Common.Model.Comment.Dto;
using Common.Model.Comment.Request;
using Common.Model.Comment.Response;
using Common.Model.ComplaintTopic.Dto;
using Common.Model.ComplaintTopic.Request;
using Common.Model.ComplaintTopic.Response;
using Common.Model.DataProviders.Coin.Coingecko.Dto;
using Common.Model.EconomicCalendar.Dto;
using Common.Model.EconomicCalendar.Response;
using Common.Model.EconomicDictionary.Dto;
using Common.Model.EconomicDictionary.Response;
using Common.Model.Formations.Dto;
using Common.Model.Formations.Response;
using Common.Model.Investment.Dto;
using Common.Model.Investment.Request;
using Common.Model.Investment.Response;
using Common.Model.Market.Dto;
using Common.Model.Market.Response;
using Common.Model.Notification.Dto;
using Common.Model.Notification.Response;
using Common.Model.OpenCloseMarkets.Dto;
using Common.Model.OpenCloseMarkets.Response;
using Common.Model.Subscription.Dto;
using Common.Model.Subscription.Request;
using Common.Model.User.Dto;
using Common.Model.User.Request;
using Common.Model.User.Response;
using Common.Model.UserComplaint.Dto;
using Common.Model.UserComplaint.Request;
using Common.Model.UserRoles.Dto;
using Common.Model.UserRoles.Request;
using Data.Entities;

namespace Infrastructure.Utility.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //Repository'den gelen GetCommentDto sınıfı, ViewModelimiz olan GetCommentModel sınıfına AutoMapper ile mapleniyor.


            #region User
            
            #region Login
            CreateMap<DtoReqLogin, ReqLogin>().ReverseMap();
            CreateMap<DtoResLogin, ResLogin>().ReverseMap();
            CreateMap<DtoUserLogins, UserLogins>().ReverseMap();
            #endregion
            #region Block

            CreateMap<DtoUserBlock, ReqUserBlock>().ReverseMap();

            #endregion
            #region Subscribe

            CreateMap<DtoUserSubscription, ReqUserSubscription>().ReverseMap();
            CreateMap<DtoUserSubscription, ReqUserBlock>().ReverseMap()
                .ForMember(x => x.SubscriberId,
                           y => y.MapFrom(z => z.BlockerId))
                .ForMember(x => x.SubscribedId,
                           y => y.MapFrom(z => z.BlockedId));

            #endregion
            #region Ban

            CreateMap<DtoBannedUser, ReqBannedUser>().ReverseMap();

            #endregion
            #region Search

            CreateMap<DtoUserSearch, ResUserSearch>().ReverseMap();

            #endregion
            #region Profile

            CreateMap<DtoUpdateUserProfile, ReqUpdateProfile>().ReverseMap();
            CreateMap<DtoGetUserProfile, UserProfiles>().ReverseMap();
            CreateMap<DtoUserProfile, ResProfile>().ReverseMap();

            #endregion
            #region SubscribersForProfile

            CreateMap<DtoGetSubscribeUser, ResGetSubscribeUser>().ReverseMap();

            #endregion
            #region GetAllUsers

            CreateMap<DtoGetUser, ResAllUsers>().ReverseMap();
            CreateMap<DtoGetUser, Users>().ReverseMap();

            #endregion
            #region Froze

            CreateMap<DtoFrozenUser, FrozenUsers>().ReverseMap();

            #endregion

            CreateMap<DtoGetLikedUserList, ResGetLikedUserList>().ReverseMap();

            CreateMap<DtoGetUserProfile, UserProfiles>().ReverseMap();
            CreateMap<DtoNameAndSurname, ResNameAndSurname>().ReverseMap();
            #endregion

            #region Complaint

            CreateMap<DtoGetComplaintTopic, ComplaintTopics>().ReverseMap();
            CreateMap<DtoGetComplaintTopic, ResGetComplaintTopic>().ReverseMap();
            CreateMap<DtoCommentComplaint, ReqCommentComplaint>().ReverseMap();
            CreateMap<DtoAddUserComplaint, ReqAddUserComplaint>().ReverseMap();

            #endregion


            
            CreateMap<DtoOpenCloseMarkets, ResOpenCloseMarkets>().ReverseMap();
            CreateMap<DtoEconomicCalendar, ResEconomicWidget>().ReverseMap();
            CreateMap<DtoEconomicFilter, ResEconomicFilter>().ReverseMap();

            CreateMap<DtoGetCommentResponse, ResGetCommentResponse>().ReverseMap();
            CreateMap<DtoGetEntry, CommentNotifications>().ReverseMap();

            CreateMap<DtoGetMarkets, ResGetMarkets>().ReverseMap();
            CreateMap<DtoAddInvestment, ReqAddInvestment>().ReverseMap();
            CreateMap<DtoUpdateInvestment, Investments>().ReverseMap();
            CreateMap<DtoUpdateInvestment, ReqUpdateInvestment>().ReverseMap();
            CreateMap<DtoGetAllInvestment, ResGetAllInvestment>().ReverseMap();
            CreateMap<DtoGetGroupInvestment, ResGetGroupInvestment>().ReverseMap();

            CreateMap<DtoGetCommentNot, ResGetCommentNot>().ReverseMap();

            CreateMap<DtoGetAllEconomicDictionary, EconomicDictionary>().ReverseMap();
            CreateMap<DtoGetAllEconomicDictionary, ResGetAllEconomicDictionary>().ReverseMap();
            CreateMap<DtoGetContent, ResGetContent>().ReverseMap();

            CreateMap<DtoGetFormation, ResGetFormation>().ReverseMap();
            CreateMap<DtoGetList, ResGetList>().ReverseMap();
            CreateMap<DtoGetAllFormations, ResGetAllFormations>().ReverseMap();

            #region UserRoles

            CreateMap<DtoAddUserRoles, ReqAddUserRoles>().ReverseMap();

            #endregion

            #region Comment
            CreateMap<DtoGetComments, ResGetComments>().ReverseMap();
            CreateMap<DtoPollOptions, ResPollOptions>().ReverseMap();
            CreateMap<DtoAddComments, ReqAddComments>().ReverseMap();
            CreateMap<DtoAddGraphicComments, ReqAddComments>().ReverseMap();
            CreateMap<DtoAddPollComment, ReqAddPoll>().ReverseMap();
            CreateMap<DtoAddPollOptions, ReqAddPoll>().ReverseMap();
            CreateMap<DtoAddComments, ReqAddPoll>().ReverseMap();
            CreateMap<DtoLikeOrDislike, ReqLikeOrDislike>().ReverseMap();
            CreateMap<CommentLikes, DtoLikeOrDislike>().ReverseMap()
                .ForMember(x => x.LikedOrDisliked,
                           y => y.MapFrom(z => z.LikeOrDislike));
            CreateMap<DtoAddPollVotes, ReqAddPollVotes>().ReverseMap();
            #endregion


            #region Markets

            CreateMap<DtoCoingeckoCoin, Markets>().ForMember(x=> x.Code,y=>y.MapFrom(z=>z.Symbol))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Icon, y => y.MapFrom(z => z.Image));

            CreateMap<DtoMarketsForCurrencyConverter, ResMarketsForCurrencyConverter>().ReverseMap();

            #endregion


        }
    }
}
