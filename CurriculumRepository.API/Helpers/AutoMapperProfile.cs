using AutoMapper;
using CurriculumRepository.API.Models;
using CurriculumRepository.CORE.Data.Models;

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
        }
    }
}
