using Common.Model.User.Dto;
using Data.Entities;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IUserProfileRepository : IEntityRepositoryBase<UserProfiles>
    {
        /// <summary>
        /// Görüntülenen kullanıcı profilini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoUserProfile> GetProfile(int userId);

        /// <summary>
        /// Kullanıcının profil ayarlarını getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoProfileSetting> GetProfileSettings(int userId);

        string GetAvatar(int userId);

        DtoNameAndSurname GetNameAndSurname(int userId);
    }
}
