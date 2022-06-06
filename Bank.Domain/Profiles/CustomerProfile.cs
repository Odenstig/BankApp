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
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(scr => scr.CustomerId))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(scr => scr.Gender))
                .ForMember(dest => dest.Givenname, opt => opt.MapFrom(scr => scr.Givenname))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(scr => scr.Surname))
                .ForMember(dest => dest.Streetaddress, opt => opt.MapFrom(scr => scr.Streetaddress))
                .ForMember(dest => dest.City, opt => opt.MapFrom(scr => scr.City))
                .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(scr => scr.Zipcode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(scr => scr.Country))
                .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(scr => scr.CountryCode))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(scr => scr.Birthday))
                .ForMember(dest => dest.Telephonecountrycode, opt => opt.MapFrom(scr => scr.Telephonecountrycode))
                .ForMember(dest => dest.Telephonenumber, opt => opt.MapFrom(scr => scr.Telephonenumber))
                .ForMember(dest => dest.Emailaddress, opt => opt.MapFrom(scr => scr.Emailaddress))
                .ReverseMap();

        }

    }
}
