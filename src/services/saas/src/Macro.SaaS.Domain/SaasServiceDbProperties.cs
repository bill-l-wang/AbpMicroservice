namespace Macro.SaaS
{
    public static class SaasServiceDbProperties
    {
        public static string DbTablePrefix { get; set; } = "";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "SaasService";
        
        public const string DefaultAdminEmailAddress = "admin@abp.io";
        
        public const string DefaultAdminPassword = "1q2w3E*";
        public const string CustomerRoleName = "customer";
    }
}
