using AutoMapper;
using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Models.Account;
using CurriculumRepository.CORE.Data.Models.Activity;
using CurriculumRepository.CORE.Data.Models.Scenario;
using CurriculumRepository.CORE.Entities;

namespace CurriculumRepository.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Account
            CreateMap<RegisterUserBM, User>();
            CreateMap<User, RegisterUserBM>();
            CreateMap<User, UpdateUserBM>();
            CreateMap<UpdateUserBM, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserDTO>();
            #endregion

            #region Scenario
            CreateMap<Ls, LsDTO>();
            CreateMap<Ls, LsBM>();
            CreateMap<LsBM, Ls>();
            #endregion

            #region Activity
            CreateMap<LaDTO, La>();
            #endregion
        }
    }
}
