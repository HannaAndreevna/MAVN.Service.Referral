﻿using System;
using System.Threading.Tasks;
using Lykke.Common.Log;
using MAVN.Service.CustomerManagement.Contract.Events;
using MAVN.Service.Referral.Domain.Services;

namespace MAVN.Service.Referral.DomainServices.Subscribers
{
    public class EmailVerifiedSubscriber: RabbitSubscriber<EmailCodeVerifiedEvent>
    {
        private readonly IFriendReferralService _friendReferralService;

        public EmailVerifiedSubscriber(
            string connectionString,
            string exchangeName,
            IFriendReferralService friendReferralService,
            ILogFactory logFactory)
            : base(connectionString, exchangeName, logFactory)
        {
            _friendReferralService = friendReferralService;

            GuidsFieldsToValidate.Add(nameof(CustomerRegistrationEvent.CustomerId));
        }

        public override async Task<(bool isSuccessful, string errorMessage)> ProcessMessageAsync(EmailCodeVerifiedEvent message)
        {
            return await _friendReferralService.AcceptAsync(Guid.Parse(message.CustomerId));
        }
    }
}
