using Macro.WebGateway.Aggregations.Base;

namespace Macro.WebGateway.Aggregations.ApplicationConfiguration;

public class AppConfigurationRequest : IRequestInput
{
    public Dictionary<string, string> Endpoints { get; } = new();
}