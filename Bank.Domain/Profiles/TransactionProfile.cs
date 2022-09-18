using AutoMapper;
using Bank.Domain.DTOs;
using Bank.Domain.Models;

namespace Bank.Domain.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(scr => scr.TransactionId))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(scr => scr.AccountId))
                .ForMember(dest => dest.RecieverAccountId, opt => opt.Ignore())
                .ForMember(dest => dest.Date, opt => opt.MapFrom(scr => scr.Date))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(scr => scr.Type))
                .ForMember(dest => dest.Operation, opt => opt.MapFrom(scr => scr.Operation))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(scr => scr.Amount))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(scr => scr.Balance))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(scr => scr.Symbol))
                .ForMember(dest => dest.Bank, opt => opt.MapFrom(scr => scr.Bank))
                .ForMember(dest => dest.Account, opt => opt.MapFrom(scr => scr.Account))
                .ReverseMap();

        }

    }
}
