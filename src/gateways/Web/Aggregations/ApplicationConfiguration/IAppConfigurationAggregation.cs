﻿using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;

namespace Macro.WebGateway.Aggregations.ApplicationConfiguration;

public interface IAppConfigurationAggregation
{
    string AppConfigRouteName { get; }
    string AppConfigEndpoint { get; }
    Task<ApplicationConfigurationDto> GetAppConfigurationAsync(AppConfigurationRequest input);
}