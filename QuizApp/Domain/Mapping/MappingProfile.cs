using AutoMapper;
using QuizApp.Domain.DTO;
using QuizApp.Domain.Entity;

namespace QuizApp.Domain.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            //UserInfo 
            CreateMap<UserInfo, userDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.MiddleName} {src.LastName}"));
        }
    }
}
