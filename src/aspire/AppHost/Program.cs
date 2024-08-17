using Macro.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddForwardedHeaders();

const string profile = "http";

// Microservices
var administrationService =
    builder.AddProject<Projects.Macro_AdministrationService_HttpApi_Host>("administrationService", profile);
var identityService = builder.AddProject<Projects.Macro_IdentityService_HttpApi_Host>("identityService", profile);

var projectService = builder.AddProject<Projects.Macro_Projects_HttpApi_Host>("cmsKitService", profile);

// Gateways
var webPublicGateway = builder.AddProject<Projects.Macro_WebGateway>("webGateway")
    .WithReference(administrationService)
    .WithReference(identityService)
    .WithReference(projectService);

// Apps
var publicWebApp = builder.AddProject<Projects.Macro_Blazor>("public-web", "https")
    .WithExternalHttpEndpoints()
    .WithReference(webPublicGateway);

builder.Build().Run();