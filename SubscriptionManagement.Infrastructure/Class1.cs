using Bogus;
using SubscriptionManagement.Domain.Entities;
using SubscriptionManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubscriptionManagement.Infrastructure
{
    public static class FakeData
    {
        public static List<Subscription> Subscriptions;
        public static void Init()
        {
            var subscriptionTypeFaker = new Faker<SubscriptionType>()
                .RuleFor(x => x.ProductId, Guid.NewGuid)
                .RuleFor(x => x.SubscriptionPeriodInDays, x => x.Random.Number(100))
                .RuleFor(x => x.Level, x => x.Random.Enum<Level>());

            var fakeFeeMoney = new Money(399, "DKK");
            var fakeRateMoney = new Money(99, "DKK");

            var pricingPlanFaker = new Faker<PricingPlan>()
                .RuleFor(x => x.FlatFee, fakeFeeMoney)
                .RuleFor(x => x.MonthlyRate, fakeRateMoney);


            var subscriptionFaker = new Faker<Subscription>()
                .RuleFor(x => x.AutomaticallyReneweble, true)
                .RuleFor(x => x.HasDefaulted, false)
                .RuleFor(x => x.Start, x => x.Date.Past(1, refDate: DateTime.Now).Date)
                .RuleFor(x => x.SubscriptionType, subscriptionTypeFaker)
                .RuleFor(x => x.PricingPlan, pricingPlanFaker);

            Subscriptions = subscriptionFaker.Generate(3);

            var addressFaker = new Faker<Address>()
                .RuleFor(x => x.Street, x => x.Address.StreetAddress())
                .RuleFor(x => x.City, x => x.Address.City())
                .RuleFor(x => x.PostalCode, x => x.Address.ZipCode());

            var userFaker = new Faker<User>()
                .RuleFor(x => x.Name, x => x.Name.FullName())
                .RuleFor(x => x.Address, addressFaker)
                .RuleFor(x => x.Subscriptions, Subscriptions);

            var users = userFaker.Generate(3);

            var k = "d";
        }
    }
}
