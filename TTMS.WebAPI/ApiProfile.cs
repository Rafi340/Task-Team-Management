using AutoMapper;
using TTMS.Application.Features.Teams.Commands;
using TTMS.Domain.Contract.Request;
using TTMS.Domain.Entities;

namespace TTMS.WebAPI
{
    public class ApiProfile : Profile
    {
        public ApiProfile() 
        {
            CreateMap<Team, TeamAddCommand>().ReverseMap();
            CreateMap<Tasks, CreateTaskRequest>().ReverseMap();
        }
    }
}
