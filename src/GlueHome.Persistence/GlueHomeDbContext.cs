using System;
using System.Threading;
using System.Threading.Tasks;
using GlueHome.Domain.Common;
using GlueHome.Domain.Entities;
using GlueHome.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GlueHome.Persistence
{
    public class GlueHomeDbContext : DbContext
    {
        public GlueHomeDbContext(DbContextOptions<GlueHomeDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GlueHomeDbContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(KeyBasedEntity).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.CurrentValues["IsDeleted"] = false;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(token);

            return result;
        }

        public DbSet<Delivery> Deliveries { get; set; }
    }
}
