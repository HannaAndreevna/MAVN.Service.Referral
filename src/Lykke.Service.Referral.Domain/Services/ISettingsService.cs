﻿namespace Lykke.Service.Referral.Domain.Services
{
    public interface ISettingsService
    {
        int GetLeadConfirmationTokenLength();
        string GetDemoEmailIdentifier();
    }
}
