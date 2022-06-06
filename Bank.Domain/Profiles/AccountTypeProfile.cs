using AutoMapper;
using Bank.Domain.Models;
using Bank.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .ReverseMap();

        }
    }
}
