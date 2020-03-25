﻿using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.Referral.Settings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }

        [AzureTableCheck]
        public string DataConnString { get; set; }

        public string MsSqlConnectionString { get; set; }
    }
}
