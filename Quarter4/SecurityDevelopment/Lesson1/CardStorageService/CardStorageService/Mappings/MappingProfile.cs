using AutoMapper;
using CardStorageService.Data;
using CardStorageService.Models;
using CardStorageService.Models.Requests;

namespace CardStorageService.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardDto>()
                .ForMember(d => d.ExpDate,
                    o => o.MapFrom(s => s.ExpDate.ToString("MM/yy")));
            CreateMap<CreateCardRequest, Card>();
            CreateMap<UpdateCardRequest, Card>();
            CreateMap<CreateClientRequest, Client>();
        }
    }
}
