using Macro.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddForwardedHeaders();

const string profile = "http";

// Microservices
var administrationService =
    builder.AddProject<Projects.Macro_AdministrationService_HttpApi_Host>("administrationService", profile);
var identityService = builder.AddProject<Projects.Macro_IdentityService_HttpApi_Host>("identityService", profile);

var saasService = builder.AddProject<Projects.Macro_Saas_HttpApi_Host>("saasService", profile);
var projectService = builder.AddProject<Projects.Macro_Projects_HttpApi_Host>("cmsKitService", profile);

// Gateways
var webPublicGateway = builder.AddProject<Projects.Macro_Gateway>("webPublicGateway")
    .WithReference(administrationService)
    .WithReference(identityService)
    .WithReference(saasService)
    .WithReference(projectService);

// Apps
var publicWebApp = builder.AddProject<Projects.Macro_Blazor>("public-web", "https")
    .WithExternalHttpEndpoints()
    .WithReference(webPublicGateway);

builder.Build().Run();