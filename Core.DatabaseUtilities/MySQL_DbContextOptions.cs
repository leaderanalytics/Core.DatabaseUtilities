
namespace LeaderAnalytics.Core.DatabaseUtilities;

public class MySQL_DbContextOptions : IDbContextOptions
{
    public DbContextOptions? Options { get; private set; }

    public MySQL_DbContextOptions(string connectionString)
    {
        BuildOptions(connectionString);
    }

    private void BuildOptions(string connectionString)
    {
        var builder = new DbContextOptionsBuilder();
        builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        Options = builder.Options;
        
    }
}
