using AutoMapper;
using SubscriptionManagement.Application.Features.GetSubscriptionsForUser;
using SubscriptionManagement.Domain.Entities;
using SubscriptionManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Features.AddSubscription
{

    //public static Subscription Map(AddSubscriptionCommand command)
    //{
    //    return new Subscription
    //    {
    //        CustomerId = command.CustomerId
    //    };
    //}
    public class MappingProfile : Profile
    {

        public static class AddSubscriptionMapper
        {
            public static Subscription Map(AddSubscriptionCommand command)
            {
                return new Subscription
                {
                    CustomerId = command.CustomerId,
                    Start = command.Start,
                    PricingPlan = new PricingPlan
                    {
                        CurrencyCode = command.CurrencyCode,
                        FlatFee = command.FlatFee,
                        MonthlyRate = command.MonthlyRate
                    },
                    Type = new SubscriptionType
                    {
                        Description = command.Description,
                        Level = (Level)Enum.Parse(typeof(Level), command.Level),
                        PeriodInDays = command.SubscriptionPeriodInDays,
                        ProductId = command.ProductId
                    }
                };
            }
        }


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
