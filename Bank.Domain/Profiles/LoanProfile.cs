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
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanDTO>()
                .ForMember(dest => dest.LoanId, opt => opt.MapFrom(scr => scr.LoanId))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(scr => scr.AccountId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(scr => scr.Date))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(scr => scr.Amount))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(scr => scr.Duration))
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(scr => scr.Payments))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(scr => scr.Status))
                .ReverseMap();
        }
    }
}
