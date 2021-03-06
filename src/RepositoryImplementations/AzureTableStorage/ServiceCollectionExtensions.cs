﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MailFunc.Common.Abstractions;
using System;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MailFunc.AzureTableStorage
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseAzureTableStorage(
            this IServiceCollection services,
            string connectionString,
            Action<AzureTableStorageSenderConfigurationRepositoryOptions> options)
        {
            services.Configure(options);
            services.TryAddScoped<IStorageAccountRetriever>(sp =>
                new StorageAccountRetriever(sp.GetRequiredService<ILogger<StorageAccountRetriever>>(), connectionString));
            services.TryAddScoped<ISenderConfigurationRepository, SenderConfigurationRepository>();
            return services;
        }
    }
}
