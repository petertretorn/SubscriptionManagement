using AutoMapper;
using SubscriptionManagement.Application.Features.GetSubscriptionsForUser;
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
                .ForMember(dest => dest.PricingPlan.FlatFee, opt => opt.MapFrom(src => src.FlatFee))
                .ForMember(dest => dest.PricingPlan.MonthlyRate, opt => opt.MapFrom(src => src.MonthlyRate))

                .ForMember(dest => dest.Type.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Type.PeriodInDays, opt => opt.MapFrom(src => src.SubscriptionPeriodInDays))
                .ForMember(dest => dest.Type.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type.Level, opt => opt.MapFrom(src => Enum.Parse(typeof(Level), src.Level)));

                
        }
    }
}
