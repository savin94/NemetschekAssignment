using AutoMapper;
using NemetschekAssignment.Core.Dtos;
using NemetschekAssignment.Models;

namespace OMS.Infrastructure.Automapper
{
    public class DefaultAutomapperProfile : Profile
    {
        public DefaultAutomapperProfile()
        {
            CreateMap<NemetschekDocument, NemetschekDocumentDto>().ReverseMap();
            CreateMap<CreateNemetschekDocumentDto, NemetschekDocument>().ReverseMap();
        }
    }
}
