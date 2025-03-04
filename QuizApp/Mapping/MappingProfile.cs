using AutoMapper;
using QuizApp.Domain.DTO;
using QuizApp.Domain.Entity;

namespace QuizApp.Mapping
{
    public class MappingProfile : Profile
    {
      public MappingProfile() {

            CreateMap<Quiz, QuestionDTO>();
            CreateMap<CreateQuestion, Quiz>();   
            CreateMap<UpdateQuestion, Quiz>();   
            CreateMap<DeleteQuestion, Quiz>();

        }
    }
}
