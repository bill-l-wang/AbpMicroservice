namespace Macro.Projects;

public static class ProjectsDbProperties
{
    public const string ConnectionStringName = "ProjectsService";
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;
}