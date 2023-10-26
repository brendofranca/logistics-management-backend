using Logistics.Management.Data.Context.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace Logistics.Management.Data.Context
{
    public class ApplicationDbContext : DbContext, IContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=logistics-management;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries()
                                  .Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                        entry.Property("CreatedAt").IsModified = false;
                        if (entry.Entity.GetType().GetProperty("TimeSpent") != null)
                        {
                            var timeSpent = DateTime.UtcNow - (DateTime)entry.OriginalValues["CreatedAt"];
                            entry.Property("TimeSpent").CurrentValue = (int)timeSpent.TotalMinutes;
                        }
                        break;
                }
            }

            try
            {
                return await base.SaveChangesAsync(cancellationToken) > 0;
            }
            catch
            {
                return false;
            }
        }

        public DbSet<T> GetDbSet<T>() where T : class => Set<T>();

        public DbConnection GetDbConnection() => Database.GetDbConnection();
    }
}