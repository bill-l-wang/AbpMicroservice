namespace Macro.Projects;

public static class ProjectsServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "ProjectsService";
}
