namespace Macro.SaaS;

public static class SaaSDbProperties
{
    public const string ConnectionStringName = "SaaSService";
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;
}