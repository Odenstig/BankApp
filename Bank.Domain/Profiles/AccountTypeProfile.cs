using AutoMapper;
using Bank.Domain.DTOs;
using Bank.Domain.Models;

namespace Bank.Domain.Profiles
{
    public class AccountTypeProfile : Profile
    {
        public AccountTypeProfile()
        {
            CreateMap<AccountType, AccountTypeDTO>()
                .ForMember(dest => dest.AccountTypeId, opt => opt.MapFrom(scr => scr.AccountTypeId))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(scr => scr.TypeName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(scr => scr.Description))
                .ForMember(dest => dest.Interest, opt => opt.MapFrom(scr => scr.Interest))
                .ReverseMap();

        }
    }
}
