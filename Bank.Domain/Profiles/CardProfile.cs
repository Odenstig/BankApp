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
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDTO>()
                .ForMember(dest => dest.CardId, opt => opt.MapFrom(scr => scr.CardId))
                .ForMember(dest => dest.DispositionId, opt => opt.MapFrom(scr => scr.DispositionId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(scr => scr.Type))
                .ForMember(dest => dest.Issued, opt => opt.MapFrom(scr => scr.Issued))
                .ForMember(dest => dest.Cctype, opt => opt.MapFrom(scr => scr.Cctype))
                .ForMember(dest => dest.Ccnumber, opt => opt.MapFrom(scr => scr.Ccnumber))
                .ForMember(dest => dest.Cvv2, opt => opt.MapFrom(scr => scr.Cvv2))
                .ForMember(dest => dest.ExpM, opt => opt.MapFrom(scr => scr.ExpM))
                .ForMember(dest => dest.ExpY, opt => opt.MapFrom(scr => scr.ExpY))
                .ReverseMap();
        }
    }
}
