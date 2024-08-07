namespace Macro.SaaS;

public static class SaasDbProperties
{
    public const string ConnectionStringName = "SaasService";
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;
}