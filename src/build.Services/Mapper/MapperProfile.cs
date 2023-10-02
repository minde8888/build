using AutoMapper;
using build.Domain.Entities;
using build.Services.Dtos;

namespace build.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Subtopic, SubtopicDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
        }
    }
}
