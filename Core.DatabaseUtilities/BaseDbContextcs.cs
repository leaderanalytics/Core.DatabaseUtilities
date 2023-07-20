using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LeaderAnalytics.Core.DatabaseUtilities
{
    public class BaseDbContext : DbContext
    {
        protected string GetDateTypeForProvider() => Database.IsSqlServer() ? "datetime2(0)" : Database.IsMySql() ? "datetime(0)" : throw new Exception("Database not recognized.");

        public BaseDbContext()
        {
            InitalizeContext();
        }

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
            InitalizeContext();
            
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancelToken = default(CancellationToken))
        {
            int result = await base.SaveChangesAsync(cancelToken);
            return result;
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();
            return result;
        }

        

        protected virtual void InitalizeContext()
        {
            // https://blog.oneunicorn.com/2012/03/12/secrets-of-detectchanges-part-3-switching-off-automatic-detectchanges/
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Database.SetCommandTimeout(360);
        }


        public IQueryable<T> GetQuery<T>() where T : class
        {
            return this.Set<T>().AsNoTracking();
        }
    }
}
