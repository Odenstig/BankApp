using AutoMapper;
using Bank.Domain.DTOs;
using Bank.Domain.Models;

namespace Bank.Domain.Profiles
{
    public class DispositionProfile : Profile
    {
        public DispositionProfile()
        {
            CreateMap<Disposition, DispositionDTO>()
                .ForMember(dest => dest.DispositionId, opt => opt.MapFrom(scr => scr.DispositionId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(scr => scr.CustomerId))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(scr => scr.AccountId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(scr => scr.Type))
                .ReverseMap();
        }

    }
}
