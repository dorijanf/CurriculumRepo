using AutoMapper;
using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Models;
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
            CreateMap<LsDTO, Ls>();
            CreateMap<Ls, LsListDTO>();
            CreateMap<LsListDTO, Ls>();
            CreateMap<Ls, LsBM>();
            CreateMap<LsBM, Ls>();
            #endregion

            #region Activity
            CreateMap<LaDTO, La>();
            CreateMap<La, LaDTO>();
            CreateMap<LaBM, La>();
            CreateMap<La, LaBM>();
            CreateMap<UpdateLaBM, La>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<La, UpdateLaBM>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region StrategyMethod
            CreateMap<StrategyMethod, StrategyMethodBM>();
            CreateMap<StrategyMethodBM, StrategyMethod>();
            #endregion
        }
    }
}
