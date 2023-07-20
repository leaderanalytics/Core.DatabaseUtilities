namespace LeaderAnalytics.Core.DatabaseUtilities;

public class MSSQL_DbContextOptions : IDbContextOptions
{
    public DbContextOptions? Options { get; private set; }

    public MSSQL_DbContextOptions(string connectionString)
    {
        BuildOptions(connectionString);
    }

    private void BuildOptions(string connectionString)
    {
        var builder = new DbContextOptionsBuilder();
        builder.UseSqlServer(connectionString);
        Options = builder.Options;
    }
}
