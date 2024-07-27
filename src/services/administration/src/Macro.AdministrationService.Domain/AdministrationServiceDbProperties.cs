namespace Macro.AdministrationService;

public static class AdministrationServiceDbProperties
{
    public const string ConnectionStringName = "AdministrationService";
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;
}