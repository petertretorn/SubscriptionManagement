using AutoMapper;
using SubscriptionManagement.Application.Features.GetSubscriptionsForUser;
using SubscriptionManagement.Domain.Entities;
using SubscriptionManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionManagement.Application.Features.AddSubscription
{

    public static class SubscriptionMapper
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
}
