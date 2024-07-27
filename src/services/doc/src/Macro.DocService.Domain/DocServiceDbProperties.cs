namespace Macro.IdentityService
{
    public static class DocServiceDbProperties
    {
        public const string ConnectionStringName = "DocService";
        public static string DbTablePrefix { get; set; } = "";

        public static string DbSchema { get; set; } = null;
    }
}
