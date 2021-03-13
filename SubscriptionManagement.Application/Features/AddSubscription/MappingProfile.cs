using AutoMapper;
using SubscriptionManagement.Domain.Entities;
using SubscriptionManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Features.AddSubscription
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddSubscriptionCommand, Subscription>()
                .ForMember(dest => dest.PricingPlan.FlatFee, opt => opt.MapFrom(src => new Money(src.FlatFee, src.CurrencyCode)))
                .ForMember(dest => dest.PricingPlan.MonthlyRate, opt => opt.MapFrom(src => new Money(src.MonthlyRate, src.CurrencyCode)))
                .ForMember(dest => dest.PricingPlan.MonthlyRate, opt => opt.MapFrom(src => new Money(src.MonthlyRate, src.CurrencyCode)))

                .ForMember(dest => dest.SubscriptionType.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.SubscriptionType.SubscriptionPeriodInDays, opt => opt.MapFrom(src => src.SubscriptionPeriodInDays))
                .ForMember(dest => dest.SubscriptionType.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SubscriptionType.Level, opt => opt.MapFrom(src => Enum.Parse(typeof(Level), src.Level)));
        }
    }
}
