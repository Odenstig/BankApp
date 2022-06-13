using AutoMapper;
using Bank.Domain.DTOs;
using Bank.Domain.Models;

namespace Bank.Domain.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(scr => scr.AccountId))
                .ForMember(dest => dest.Frequency, opt => opt.MapFrom(scr => scr.Frequency))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(scr => scr.Created))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(scr => scr.Balance))
                .ForMember(dest => dest.AccountTypesId, opt => opt.MapFrom(scr => scr.AccountTypesId))
                .ReverseMap();
        }
    }
}
